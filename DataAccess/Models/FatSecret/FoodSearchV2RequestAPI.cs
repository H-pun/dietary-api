using Dietary.Base;

namespace Dietary.DataAccess.Models
{
    public class FoodSearchV2RequestAPI
    {
        public string method { get; set; } = "foods.search.v2";
        public string search_expression { get; set; }
        public int page_number { get; set; }
        public bool include_sub_categories { get; set; }
        public bool flag_default_serving { get; set; }
        public string region { get; set; } = "ID";
        public string language { get; set; } = "id";
        public string format { get; set; } = "json";
        public FoodSearchV2RequestAPI(FoodSearchV2Request request)
        {
            search_expression = request.FoodName;
            page_number = request.PageNumber;
            include_sub_categories = request.IncludeSubCategories;
            flag_default_serving = request.FlagDefaultServing;
        }
    }
}
