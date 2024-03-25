using Dietary.Base;

namespace Dietary.DataAccess.Models
{
    public class FoodSearchV2Request
    {
        public string FoodName { get; set; }
        public int PageNumber { get; set; } = 0;
        public int MaxResults { get; set; } = 50;
        public bool IncludeSubCategories { get; set; } = true;
        public bool FlagDefaultServing { get; set; } = true;
    }
}
