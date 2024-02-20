using Microsoft.EntityFrameworkCore;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Models;
using Dietary.Helpers;
using System.Net;
using System.Security.Claims;
using System.Text;
using Dietary.DataAccess.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Dynamic;

namespace Dietary.DataAccess.Services
{
    // public interface IFatSecretService : IBaseService<User>
    // {
    //     Task<LoginResponse> Login(string username, string password);
    //     Task ChangePassword(ChangePasswordRequest model);
    // }
    public class FatSecretService
    {
        protected readonly HttpClient _client = new();
        protected readonly HttpContext _httpContext;
        public readonly IConfiguration _configuration;
        public FatSecretService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContext = httpContextAccessor.HttpContext;
            var byteArray = Encoding.ASCII.GetBytes($"{configuration["FatSecretClientId"]}:{configuration["FatSecretClientSecret"]}");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
            var token = JsonConvert.DeserializeObject<AccessTokenResponse>(_httpContext.Session.GetString("fatsecretToken"));
            
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            var response = await _client.PostAsync("https://platform.fatsecret.com/rest/server.api", request.ToFormData());
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ExpandoObject>(responseString);
        }
    }
}
