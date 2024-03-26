using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dietary.DataAccess.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class FoodSearchV2Response : BaseModel
    {
        public int MaxResults { get; set; }
        public int TotalResults { get; set; }
        public int PageNumber { get; set; }
        public List<FatSecretFoodResponse> Foods { get; set; }
        public override List<TEntity> MaptoListEntity<TEntity>()
        {
            return [.. Foods.Select(food => food.MapToEntity<TEntity>())];
        }
    }
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class FatSecretFoodResponse : BaseModel
    {
        public long FoodId { get; set; }
        public string FoodName { get; set; }
        public string BrandName { get; set; }
        public string FoodType { get; set; }
        public string FoodUrl { get; set; }
        public List<FatSecretServingResponse> Servings { get; set; }
        public override TEntity MapToEntity<TEntity>()
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<FatSecretFoodResponse, FatSecretFood>().ForMember(dest => dest.Servings, opt => opt.Ignore())).CreateMapper();
            FatSecretFood entity = mapper.Map<FatSecretFoodResponse, FatSecretFood>(this);
            entity.Servings = [.. Servings.Select(serving => serving.MapToEntity<FatSecretServing>())];
            return entity as TEntity;
        }
    }
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class FatSecretServingResponse : BaseModel
    {
        public long ServingId { get; set; }
        public string ServingDescription { get; set; }
        public string ServingUrl { get; set; }
        public float NumberOfUnits { get; set; }
        public string MeasurementDescription { get; set; }
        [JsonConverter(typeof(BoolConverter))]
        public bool IsDefault { get; set; }
        public float Calories { get; set; }
        public float Carbohydrate { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float SaturatedFat { get; set; }
        public float TransFat { get; set; }
        public float Cholesterol { get; set; }
        public float Sodium { get; set; }
        public float Potassium { get; set; }
        public float Fiber { get; set; }
        public float Sugar { get; set; }
        public float AddedSugars { get; set; }
        public float Calcium { get; set; }
        public float Iron { get; set; }
        public float MetricServingAmount { get; set; }
        public string MetricServingUnit { get; set; }
        public float PolyunsaturatedFat { get; set; }
        public float MonounsaturatedFat { get; set; }
        public float VitaminD { get; set; }
        public float VitaminA { get; set; }
        public float VitaminC { get; set; }
    }
}
