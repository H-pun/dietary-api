using System.Text.Json.Serialization;
using Dietary.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dietary.DataAccess.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class AccessTokenResponse
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
    }
}
