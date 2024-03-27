using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;
using AutoMapper;
using Compunet.YoloV8.Timing;
using Compunet.YoloV8.Data;

namespace Dietary.DataAccess.Models
{
    public class Bounding(BoundingBox box)
    {
        public int X { get; set; } = box.Bounds.X;
        public int Y { get; set; } = box.Bounds.Y;
        public int Width { get; set; } = box.Bounds.Width;
        public int Height { get; set; } = box.Bounds.Height;
    }
    public class PredictResult(BoundingBox box)
    {
        public Bounding Bounds { get; set; } = new(box);
        public float Confidence { get; set; } = box.Confidence;
    }
    public class PredictedFood
    {
        public DetailFoodResponse FoodDetail { get; set; }
        public PredictResult PredictResult { get; set; }
    }
    public class DetailPredictResponse : BaseModel
    {
        public List<PredictedFood> Foods { get; set; }
        public SpeedResult ProcessTime { get; set; }
        public float TotalCalories => Foods.Select(x => x.FoodDetail.Serving.Calories).Sum();
    }
}
