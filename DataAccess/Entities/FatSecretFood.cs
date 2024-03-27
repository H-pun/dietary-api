using Dietary.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Dietary.DataAccess.Extensions;
using Dietary.Helpers;

namespace Dietary.DataAccess.Entities
{
    public class FatSecretFood : BaseEntity
    {
        public long FoodId { get; set; }
        public string FoodName { get; set; }
        public string BrandName { get; set; }
        public string FoodType { get; set; }
        public string FoodUrl { get; set; }
        public ICollection<FatSecretServing> Servings { get; set; } = new HashSet<FatSecretServing>();
        public Food Food { get; set; }
    }
}
