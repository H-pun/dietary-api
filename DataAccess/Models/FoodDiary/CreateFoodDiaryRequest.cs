using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;

namespace Dietary.DataAccess.Models
{
    public class CreateFoodDiaryRequest : BaseModel
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime AddedAt { get; set; }
        public IFormFile File { get; set; }
    }
}
