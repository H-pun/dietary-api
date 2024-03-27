using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;

namespace Dietary.DataAccess.Models
{
    public class DetailFoodResponse : BaseModel
    {
        public Guid Id { get; set; }
        public long IdOriginal { get; set; }
        public string Name { get; set; }
        public string ModelName { get; set; }
        public string FoodUrl { get; set; }
        public FatSecretServingResponse Serving { get; set; } = new();
        public DetailFoodResponse()
        {
            IncludeProperty(["FatSecretData", "FatSecretData.Servings"]);
        }
        public override void MapToModel<TEntity>(TEntity entity)
        {
            Food food = entity as Food;
            Id = food.Id;
            IdOriginal = food.FatSecretData.FoodId;
            Name = food.FatSecretData.FoodName;
            ModelName = food.Name;
            FoodUrl = food.FatSecretData.FoodUrl;
            Serving.MapToModel(food.FatSecretData.Servings.FirstOrDefault(x => x.IsDefault));
        }
    }
}
