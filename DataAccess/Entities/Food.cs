using Dietary.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Dietary.DataAccess.Extensions;
using Dietary.Helpers;

namespace Dietary.DataAccess.Entities
{
    public class Food : BaseEntity
    {
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
