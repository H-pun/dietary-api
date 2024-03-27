using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;

namespace Dietary.DataAccess.Models
{
    public class UpdateFoodRequest : BaseModel
    {
        public Guid Id { get; set; }
        public Guid IdFatSecret { get; set; }
        public string Name { get; set; }
    }
}
