using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;

namespace Dietary.DataAccess.Models
{
    public class DetailUserDataResponse : BaseModel
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Email { get; set; }
        public string AppToken { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string Gender { get; set; }
        public string Goal { get; set; }
        public float WeightTarget { get; set; }
        public string ActivityLevel { get; set; }
        public DetailUserDataResponse()
        {
            IncludeProperty(["User"]);
        }

        public override void MapToModel<TEntity>(TEntity entity)
        {
            if (entity is UserData u)
            {
                base.MapToModel(u);
                IdUser = u.IdUser;
                Email = u.User.Email;
                AppToken = u.User.AppToken;
            }
        }
    }
}
