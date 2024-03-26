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
        Task<dynamic> SearchV2(FoodSearchV2Request v2Request);
        Task<CreateFoodRequest> Scrap(CreateFoodRequest food);
        Task BulkInsert(FoodSearchV2Response model);
    }
    public class FatSecretService : BaseService<FatSecretFood>, IFatSecretService
    {
        protected readonly HttpClient _client = new();
        protected readonly HttpContext _httpContext;
        public readonly IConfiguration _configuration;
        private AccessTokenResponse _token;
        private readonly List<CreateFoodRequest> foods =
        [
            new() { Name = "Ayam Bakar", Url= "https://www.fatsecret.co.id/kalori-gizi/umum/paha-ayam-panggang-(kulit-dimakan)?portionid=6417&portionamount=1,000"},
            new() { Name = "Ayam Goreng", Url= "https://www.fatsecret.co.id/kalori-gizi/umum/paha-ayam-goreng-tanpa-pelapis-(kulit-dimakan)?portionid=5675&portionamount=1,000"},
            new() { Name = "Bakso", Url="https://www.fatsecret.co.id/kalori-gizi/umum/bakso-daging-sapi?portionid=570240&portionamount=1,000"},
            new() { Name = "Bakwan", Url= "https://www.fatsecret.co.id/kalori-gizi/umum/bakwan?portionid=5125714&portionamount=1,000"},
            // new() { Name = "Batagor", Url = "https://www.example.com/batagor" },
            new() { Name = "Bihun", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/bihun-goreng?portionid=10145518&portionamount=1,000" },
            new() { Name = "Capcay", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/cap-cay-kuah?portionid=8088335&portionamount=1,000" },
            new() { Name = "Gado-Gado", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/gado-gado?portionid=8730722&portionamount=1,000" },
            new() { Name = "Ikan Goreng", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/ikan-tongkol-goreng?portionid=6406307&portionamount=1,000" },
            new() { Name = "Kerupuk", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/kerupuk-putih?portionid=34466335&portionamount=1,000" },
            new() { Name = "Martabak Telur", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/martabak-telur?portionid=19305165&portionamount=1,000" },
            new() { Name = "Mie", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/mie-telur-(ditambah-masak)?portionid=40394&portionamount=1,000" },
            new() { Name = "Nasi Goreng", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/nasi-goreng?portionid=18686&portionamount=1,000" },
            new() { Name = "Nasi Putih", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/nasi-putih?portionid=17592&portionamount=1,000" },
            new() { Name = "Nugget", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/chicken-nugget?portionid=5851&portionamount=1,000" },
            new() { Name = "Opor Ayam", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/opor-ayam?portionid=9706245&portionamount=1,000" },
            // new() { Name = "Pempek", Url = "https://www.example.com/pempek" },
            new() { Name = "Rendang", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/rendang?portionid=5737372&portionamount=1,000" },
            new() { Name = "Roti", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/roti?portionid=333747&portionamount=1,000" },
            // new() { Name = "Sate", Url = "https://www.example.com/sate" },
            new() { Name = "Sosis", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/sosis-ayam?portionid=342766&portionamount=1,000" },
            new() { Name = "Soto", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/soto-ayam?portionid=5702664&portionamount=1,000" },
            // new() { Name = "Steak", Url = "https://www.example.com/steak" },
            new() { Name = "Tahu", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/tahu-goreng?portionid=37727&portionamount=1,000" },
            new() { Name = "Telur", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/telur?portionid=12039&portionamount=1,000" },
            new() { Name = "Tempe", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/tempe-goreng?portionid=4968998&portionamount=1,000" },
            // new() { Name = "Terong Balado", Url = "https://www.example.com/terong_balado" },
            new() { Name = "Tumis Kangkung", Url = "https://www.fatsecret.co.id/kalori-gizi/umum/tumis-kangkung?portionid=5049096&portionamount=1,000" },
            // new() { Name = "Udang", Url = "https://www.example.com/udang" }
        ];
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
        public async Task<dynamic> SearchV2(FoodSearchV2Request v2Request)
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
        public async Task<List<CreateFoodRequest>> GetSeeder()
        {
            List<CreateFoodRequest> foodData = [];
            foreach (var food in foods) foodData.Add(await Scrap(food));
            return foodData;
        }
        public async Task<CreateFoodRequest> Scrap(CreateFoodRequest food)
        {
            HttpResponseMessage response = await _client.GetAsync(food.Url);
            var document = await response.ParseHtml();

            var webName = document.QuerySelector(".summarypanelcontent h1").TextContent.Trim();
            var portion = document.QuerySelector(".summarypanelcontent h2");
            var portionDetail = portion.FirstChild.TextContent[2..].Trim();

            var spanText = portion.QuerySelector("span")?.TextContent.Trim();
            if (spanText != null) portionDetail += portionDetail == "porsi" ? $" {spanText.Replace(" ", "")}" : $" {spanText}";

            var propAlias = new Dictionary<string, string>
                {
                    { "Kal", "Calories" },
                    { "Lemak", "Fat" },
                    { "Karb", "Carbohydrate" },
                    { "Prot", "Protein" }
                };

            food.WebName = webName;
            food.Unit = portionDetail;

            var nutrients = document.QuerySelector("div.factPanel");
            var facts = nutrients.QuerySelectorAll("td.fact");

            foreach (var fact in facts)
            {
                var factTitle = fact.QuerySelector(".factTitle").TextContent.Trim();
                var factValue = float.Parse(fact.QuerySelector(".factValue").TextContent.Replace(',', '.').Trim().TrimEnd('g'));
                food.GetType().GetProperty(propAlias[factTitle]).SetValue(food, factValue);
            }

            return food;
        }
        public async Task BulkInsert(FoodSearchV2Response model)
        {
            List<FatSecretFood> foods = model.MaptoListEntity<FatSecretFood>();
            await _appDbContext.Set<FatSecretFood>().AddRangeAsync(foods);
            await _appDbContext.SaveChangesAsync();
        }
        private async Task SetToken()
        {
            var tokenString = _httpContext.Session.GetString("fatsecretToken");
            _token = tokenString != null ? JsonConvert.DeserializeObject<AccessTokenResponse>(tokenString) : await GetAccessToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.AccessToken);
        }
    }
}
