using System.Text.Json.Serialization;
using Dietary.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dietary.DataAccess.Models
{
    public class FoodSearchSeedingResponse : FoodSearchV2Response
    {
        public int TotalDataInserted { get; set; }
        public FoodSearchSeedingResponse(FoodSearchV2Response data)
        {
            MaxResults = data.MaxResults;
            TotalResults = data.TotalResults;
            PageNumber = data.PageNumber;
            Foods = data.Foods;
        }
    }
}
