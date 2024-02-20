using Dietary.Base;
using Dietary.Helpers;

namespace Dietary.DataAccess.Entities
{
    public class User : BaseEntity
    {
        private string _password;
        public string Email { get; set; }
        public string Password { get => _password; set => _password = _password == null ? value?.HashPassword() : value; }
        public string AppToken { get; set; }
        public UserData UserData { get; set; }
        public ICollection<FoodDiary> FoodDiary { get; set; } = new HashSet<FoodDiary>();
    }
}
