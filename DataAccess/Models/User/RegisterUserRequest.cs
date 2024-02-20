using Dietary.Base;
using Dietary.DataAccess.Entities;

namespace Dietary.DataAccess.Models
{
    public class RegisterUserRequest : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
