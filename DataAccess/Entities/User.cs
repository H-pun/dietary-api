using Dietary.Base;
using Dietary.Helpers;

namespace Dietary.DataAccess.Entities
{
    public class User : BaseEntity
    {
        private string _password;
        private string _name;
        public string Email { get; set; }
        public string Name { get => _name; set => _name = value?.ToTitleCase(); }
        public string Password { get => _password; set => _password = _password == null ? value?.HashPassword() : value; }
        public string AppToken { get; set; }
        public UserData UserData { get; set; }
        public FoodDiary FoodDiary { get; set; }
    }
}
