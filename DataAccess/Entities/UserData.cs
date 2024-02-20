using Dietary.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Dietary.DataAccess.Extensions;
using Dietary.Helpers;

namespace Dietary.DataAccess.Entities
{
    public class UserData : BaseEntity
    {
        private string _username;
        public Guid IdUser { get; set; }
        public string Username { get => _username; set => _username = value?.ToLower(); }
        public int Age { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string Gender { get; set; }
        public string Goal { get; set; }
        public float WeightTarget { get; set; }
        public string ActivityLevel { get; set; }
        [ForeignKey(nameof(IdUser))]
        public User User { get; set; }
    }
}
