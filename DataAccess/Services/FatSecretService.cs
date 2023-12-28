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
        protected readonly HttpRequest _httpRequest;
        public readonly IConfiguration _configuration;
        public FatSecretService(IHttpContextAccessor httpRequest, IConfiguration configuration)
        {
            _configuration = configuration;
            var byteArray = Encoding.ASCII.GetBytes($"{configuration["FatSecretClientId"]}:{configuration["FatSecretClientSecret"]}");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
        public async Task<dynamic> GetAccessToken()
        {
            var request = new GetAccessTokenRequest(_configuration);
            var response = await _client.PostAsync("https://oauth.fatsecret.com/connect/token", request.ToFormData());
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AccessTokenResponse>(responseString);
        }
    }
}
