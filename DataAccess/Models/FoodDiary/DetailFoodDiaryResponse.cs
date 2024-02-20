using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;

namespace Dietary.DataAccess.Models
{
    public class DetailFoodDiaryResponse : BaseModel
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public float TotalCaloriesToday { get; set; }
        public float MaxDailyBmrCalories { get; set; }
        public float TotalFoodCalories { get; set; }
        public string Status { get; set; }
        public string Feedback { get; set; }
        public dynamic Foods { get; set; }
        public DateTime AddedAt { get; set; }
        public string FilePath { get; set; }
    }
}
