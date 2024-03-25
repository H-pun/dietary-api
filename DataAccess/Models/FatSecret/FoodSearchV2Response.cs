using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;
using AutoMapper;

namespace Dietary.DataAccess.Models
{
    public class FoodSearchV2Response(dynamic data) : BaseModel
    {
        public int MaxResults { get; set; } = data.max_results;
        public int TotalResults { get; set; } = data.total_results;
        public int PageNumber { get; set; } = data.page_number;
        public List<FatSecretFoodResponse> Foods { get; set; } = ((IEnumerable<dynamic>)data.results.food).Select(x => new FatSecretFoodResponse(x)).ToList();
        public override List<TEntity> MaptoListEntity<TEntity>()
        {
            return [.. Foods.Select(food => food.MapToEntity<TEntity>())];
        }
    }
    public class FatSecretFoodResponse(dynamic data) : BaseModel
    {
        public long FoodId { get; set; } = data.food_id;
        public string FoodName { get; set; } = data.food_name;
        public string BrandName { get; set; } = data.brand_name;
        public string FoodType { get; set; } = data.food_type;
        public string FoodUrl { get; set; } = data.food_url;
        public List<FatSecretServingResponse> Servings { get; set; } = ((IEnumerable<dynamic>)data.servings.serving).Select(x => new FatSecretServingResponse(x)).ToList();
        public override TEntity MapToEntity<TEntity>()
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<FatSecretFoodResponse, FatSecretFood>().ForMember(dest => dest.Servings, opt => opt.Ignore())).CreateMapper();
            FatSecretFood entity = mapper.Map<FatSecretFoodResponse, FatSecretFood>(this);
            entity.Servings = [.. Servings.Select(serving => serving.MapToEntity<FatSecretServing>())];
            return entity as TEntity;
        }
    }
    public class FatSecretServingResponse(dynamic data) : BaseModel
    {
        public long ServingId { get; set; } = data.serving_id;
        public string ServingDescription { get; set; } = data.serving_description;
        public string ServingUrl { get; set; } = data.serving_url;
        public float NumberOfUnits { get; set; } = data.number_of_units;
        public string MeasurementDescription { get; set; } = data.measurement_description;
        public bool IsDefault { get; set; } = data.is_default == 1;
        public float Calories { get; set; } = data.calories;
        public float Carbohydrate { get; set; } = data.carbohydrate;
        public float Protein { get; set; } = data.protein;
        public float Fat { get; set; } = data.fat;
        public float SaturatedFat { get; set; } = data.saturated_fat ?? 0;
        public float TransFat { get; set; } = data.trans_fat ?? 0;
        public float Cholesterol { get; set; } = data.cholesterol ?? 0;
        public float Sodium { get; set; } = data.sodium ?? 0;
        public float Potassium { get; set; } = data.potassium ?? 0;
        public float Fiber { get; set; } = data.fiber ?? 0;
        public float Sugar { get; set; } = data.sugar ?? 0;
        public float AddedSugars { get; set; } = data.added_sugars ?? 0;
        public float Calcium { get; set; } = data.calcium ?? 0;
        public float Iron { get; set; } = data.iron ?? 0;
        public float MetricServingAmount { get; set; } = data.metric_serving_amount ?? 0;
        public string MetricServingUnit { get; set; } = data.metric_serving_unit;
        public float PolyunsaturatedFat { get; set; } = data.polyunsaturated_fat ?? 0;
        public float MonounsaturatedFat { get; set; } = data.monounsaturated_fat ?? 0;
        public float VitaminD { get; set; } = data.vitamin_d ?? 0;
        public float VitaminA { get; set; } = data.vitamin_a ?? 0;
        public float VitaminC { get; set; } = data.vitamin_c ?? 0;
    }
}
