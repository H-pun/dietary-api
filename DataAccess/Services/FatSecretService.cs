using System.Net.Http.Headers;
using System.Text;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Extensions;
using Dietary.DataAccess.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dietary.DataAccess.Services
{
    public interface IFatSecretService : IBaseService<FatSecretFood>
    {
        Task<AccessTokenResponse> GetAccessToken();
        Task<FoodSearchV2Response> SearchV2(FoodSearchV2Request v2Request);
        Task<dynamic> Scrap(string food);
        Task<int> BulkInsert(FoodSearchV2Response model);
    }
    public class FatSecretService : BaseService<FatSecretFood>, IFatSecretService
    {
        protected readonly HttpClient _client = new();
        protected readonly HttpContext _httpContext;
        public readonly IConfiguration _configuration;
        private AccessTokenResponse _token;
        public FatSecretService(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(appDbContext)
        {
            _configuration = configuration;
            _httpContext = httpContextAccessor.HttpContext;
            _client.DefaultRequestHeaders.Add("User-Agent", "Other");
            _client.DefaultRequestHeaders.Authorization = new("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{configuration["FatSecretClientId"]}:{configuration["FatSecretClientSecret"]}")));
        }
        public async Task<AccessTokenResponse> GetAccessToken()
        {
            var request = new GetAccessTokenRequestAPI(_configuration);
            var response = await _client.PostAsync("https://oauth.fatsecret.com/connect/token", request.ToFormData());
            var responseString = await response.Content.ReadAsStringAsync();
            _httpContext.Session.SetString("fatsecretToken", responseString);

            return JsonConvert.DeserializeObject<AccessTokenResponse>(responseString);
        }
        public async Task<FoodSearchV2Response> SearchV2(FoodSearchV2Request v2Request)
        {
            await SetToken();
            var request = new FoodSearchV2RequestAPI(v2Request);
            var response = await _client.PostAsync("https://platform.fatsecret.com/rest/server.api", request.ToFormData());
            var responseString = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(responseString)["foods_search"] as JObject;
            json.Add(new JProperty("foods", json["results"]["food"]));
            foreach (var food in json["foods"]) food["servings"] = food["servings"]["serving"];
            FoodSearchV2Response res = json.ToObject<FoodSearchV2Response>();
            return res;
        }
        public async Task<dynamic> Scrap(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            var document = await response.ParseHtml();

            var webName = document.QuerySelector(".summarypanelcontent h1").TextContent.Trim();
            var portion = document.QuerySelector(".summarypanelcontent h2");
            var portionDetail = portion.FirstChild.TextContent.Trim();

            var spanText = portion.QuerySelector("span")?.TextContent.Trim();
            if (spanText != null) portionDetail += portionDetail == "porsi" ? $" {spanText.Replace(" ", "")}" : $" {spanText}";

            var propAlias = new Dictionary<string, string>
                {
                    { "Kal", "Calories" },
                    { "Lemak", "Fat" },
                    { "Karb", "Carbohydrate" },
                    { "Prot", "Protein" }
                };

            var result = new Dictionary<string, dynamic>
            {
                { "WebName", webName },
                { "unit", portionDetail }
            };

            var nutrients = document.QuerySelector("div.factPanel");
            var facts = nutrients.QuerySelectorAll("td.fact");

            foreach (var fact in facts)
            {
                var factTitle = fact.QuerySelector(".factTitle").TextContent.Trim();
                var factValue = float.Parse(fact.QuerySelector(".factValue").TextContent.Replace(',', '.').Trim().TrimEnd('g'));
                result.Add(propAlias[factTitle], factValue);
            }

            return result;
        }
        public async Task<int> BulkInsert(FoodSearchV2Response model)
        {
            List<FatSecretFood> foods = [.. model.MaptoListEntity<FatSecretFood>().Where(newFood => !_appDbContext.Set<FatSecretFood>().Any(exixtingFood => newFood.FoodName == exixtingFood.FoodName && newFood.BrandName == exixtingFood.BrandName))];
            await _appDbContext.Set<FatSecretFood>().AddRangeAsync(foods);
            await _appDbContext.SaveChangesAsync();
            return foods.Count;
        }
        private async Task SetToken()
        {
            var tokenString = _httpContext.Session.GetString("fatsecretToken");
            _token = tokenString != null ? JsonConvert.DeserializeObject<AccessTokenResponse>(tokenString) : await GetAccessToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.AccessToken);
        }
    }
}
