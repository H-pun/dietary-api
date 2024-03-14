using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;

namespace Dietary.DataAccess.Models
{
    public class DetailFoodDiaryRequest : BaseModel
    {
        public Guid IdUser { get; set; }
        public DateTime? Date { get; set; }
    }
}
