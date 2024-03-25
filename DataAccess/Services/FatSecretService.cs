using System.Net.Http.Headers;
using System.Text;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Extensions;
using Dietary.DataAccess.Models;
using Newtonsoft.Json;


namespace Dietary.DataAccess.Services
{
    public interface IFatSecretService : IBaseService<FatSecretFood>
    {
        Task<AccessTokenResponse> GetAccessToken();
        Task<dynamic> SearchV2(FoodSearchV2Request v2Request);
        Task<CreateFoodRequest> Scrap(CreateFoodRequest food);
    }
    public class FatSecretService : BaseService<FatSecretFood>, IFatSecretService
    {
        protected readonly HttpClient _client = new();
        protected readonly HttpContext _httpContext;
        public readonly IConfiguration _configuration;
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
            _client.DefaultRequestHeaders.Authorization = new(
                "Basic", Convert.ToBase64String(
                    Encoding.ASCII.GetBytes($"{configuration["FatSecretClientId"]}:{configuration["FatSecretClientSecret"]}")
                ));
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
            var request = new FoodSearchV2RequestAPI(v2Request);
            var token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjQ4NDUzNUJFOUI2REY5QzM3M0VDNUNBRTRGMEJFNUE2QTk3REQ3QkMiLCJ0eXAiOiJhdCtqd3QiLCJ4NXQiOiJTRVUxdnB0dC1jTno3Rnl1VHd2bHBxbDkxN3cifQ.eyJuYmYiOjE3MTEzNjAyMzksImV4cCI6MTcxMTQ0NjYzOSwiaXNzIjoiaHR0cHM6Ly9vYXV0aC5mYXRzZWNyZXQuY29tIiwiYXVkIjpbImJhcmNvZGUiLCJiYXNpYyIsImxvY2FsaXphdGlvbiIsInByZW1pZXIiXSwiY2xpZW50X2lkIjoiYWUyMWJmNWM1Yjg0NGRiZThlMDQ1MGM5ZTFjZmM0MTYiLCJzY29wZSI6WyJiYXJjb2RlIiwiYmFzaWMiLCJsb2NhbGl6YXRpb24iLCJwcmVtaWVyIl19.hmZB_64pbGHI3Ek4D_UgWIptVP66g9cOmMb6vacgN7xxR9zq_jaOnd8ic8OtDHD-lZLqCISKpwvgCJt9DP4lbilw0X1vmNvctrNfE7YHBJHjzTUyYTw2q0ynbkK1eMiFpA-UwK4ua7A6rZL6JY8fHef-dQ3EiF3zDlZrf_xN0xocNHs1z6iBnGJkyhSUgQHIEm5GBTFiFHc0gqcDbEJ7NslVEvfFsIZx6UoxnPVF1WSsIrzgQA9T1hlshKiCMwSFMhmkQauIWcZ4YytkKxrBNd43TFA3VjXTim7cq5ZvHACnsb7Z0bT5id69emH8FPV3LR_HMfZx7C--xQf1Xe2xGw";
            //JsonConvert.DeserializeObject<AccessTokenResponse>(_httpContext.Session.GetString("fatsecretToken"));

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsync("https://platform.fatsecret.com/rest/server.api", request.ToFormData());
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(responseString).foods_search;
            return new FoodSearchV2Response(result);
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
    }
}
