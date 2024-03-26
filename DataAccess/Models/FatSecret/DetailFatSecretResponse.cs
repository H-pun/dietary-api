using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;
using AutoMapper;

namespace Dietary.DataAccess.Models
{
    public class DetailFatSecretResponse : FatSecretFoodResponse
    {
        public Guid Id { get; set; }
        public DetailFatSecretResponse()
        {
            IncludeProperty(["Servings"]);
        }
        public override void MapToModel<TEntity>(TEntity entity)
        {
            FatSecretFood food = entity as FatSecretFood;
            IMapper foodMapper = new MapperConfiguration(cfg => cfg.CreateMap<FatSecretFood, DetailFatSecretResponse>().ForMember(dest => dest.Servings, opt => opt.Ignore())).CreateMapper();
            IMapper servingMapper = new MapperConfiguration(cfg => cfg.CreateMap<FatSecretServing, FatSecretServingResponse>()).CreateMapper();
            foodMapper.Map(food, this);
            Servings = [.. food.Servings.Select(x => servingMapper.Map<FatSecretServingResponse>(x))];
        }
    }
}
