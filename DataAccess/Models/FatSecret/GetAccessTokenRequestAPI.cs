using Dietary.Base;

namespace Dietary.DataAccess.Models
{
    public class GetAccessTokenRequestAPI
    {
        public string grant_type { get; set; } = "client_credentials";
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string scope { get; set; } // = "basic premier";

        public GetAccessTokenRequestAPI(IConfiguration configuration)
        {
            client_id = configuration["FatSecretClientId"];
            client_secret = configuration["FatSecretClientSecret"];
        }
    }
}
