using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;

namespace Dietary.DataAccess.Models
{
    public class CreateUserDataRequest : BaseModel
    {
        public Guid IdUser { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string Gender { get; set; }
        public string Goal { get; set; }
        public float WeightTarget { get; set; }
        public string ActivityLevel { get; set; }
    }
}
