using Dietary.Base;

namespace Dietary.DataAccess.Models
{
    public class GetAccessTokenRequestAPI(IConfiguration configuration)
    {
        public string grant_type { get; set; } = "client_credentials";
        public string client_id { get; set; } = configuration["FatSecretClientId"];
        public string client_secret { get; set; } = configuration["FatSecretClientSecret"];
        public string scope { get; set; } // = "basic premier";
    }
}
