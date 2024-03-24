using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;
using AutoMapper;

namespace Dietary.DataAccess.Models
{
    public class DetailPredictResponse : DetailFoodResponse
    {
        public PredictResult PredictResult { get; set; }

        public void MapToModel(DetailFoodResponse detailFood)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap(typeof(DetailFoodResponse), GetType())).CreateMapper();
            mapper.Map(detailFood, this);
        }
    }
}
