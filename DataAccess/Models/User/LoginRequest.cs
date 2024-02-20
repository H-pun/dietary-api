using Dietary.Base;

namespace Dietary.DataAccess.Models
{
    public class LoginRequest : BaseModel
    {
        private string _email;
        public string Email { get => _email; set => _email = value?.ToLower(); }
        public string Password { get; set; }
    }
}
