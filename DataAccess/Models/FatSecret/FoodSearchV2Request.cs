using Dietary.Base;

namespace Dietary.DataAccess.Models
{
    public class FoodSearchV2Request
    {
        public string FoodName { get; set; }
        public int PageNumber { get; set; } = 0;
        public int MaxResults { get; set; } = 50;
        // public bool IncludeSubCategories { get; set; } = false;
        // public bool FlagDefaultServing { get; set; } = true;
    }
    public class FoodSearchV2RequestAPI(FoodSearchV2Request request)
    {
        public string method { get; set; } = "foods.search.v2";
        public string search_expression { get; set; } = request.FoodName;
        public int page_number { get; set; } = request.PageNumber;
        public int max_results { get; set; } = request.MaxResults;
        public bool include_sub_categories { get; set; } = false; //request.IncludeSubCategories;
        public bool flag_default_serving { get; set; } = true; //request.FlagDefaultServing;
        public string region { get; set; } = "ID";
        public string language { get; set; } = "id";
        public string format { get; set; } = "json";
    }
}
