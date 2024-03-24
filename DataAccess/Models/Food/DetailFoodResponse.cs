using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;

namespace Dietary.DataAccess.Models
{
    public class DetailFoodResponse : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WebName { get; set; }
        public string Unit { get; set; }
        public float Calories { get; set; }
        public float Fat { get; set; }
        public float Protein { get; set; }
        public float Carbohydrate { get; set; }
        public string Url { get; set; }
    }
}
