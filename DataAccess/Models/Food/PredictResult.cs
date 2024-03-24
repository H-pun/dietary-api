using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;
using Compunet.YoloV8.Data;

namespace Dietary.DataAccess.Models
{
    public class PredictResult(BoundingBox box) : BaseModel
    {
        public int X { get; set; } = box.Bounds.X;
        public int Y { get; set; } = box.Bounds.Y;
        public int Width { get; set; } = box.Bounds.Width;
        public int Height { get; set; } = box.Bounds.Height;
        public float Confidence { get; set; } = box.Confidence;
    }
}
