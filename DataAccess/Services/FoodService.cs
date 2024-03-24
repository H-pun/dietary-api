using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Models;

namespace Dietary.DataAccess.Services
{
    public interface IFoodService : IBaseService<Food>
    {
        Task BulkInsert(List<CreateFoodRequest> model);
    }
    public class FoodService(AppDbContext appDbContext) : BaseService<Food>(appDbContext), IFoodService
    {
        public async Task BulkInsert(List<CreateFoodRequest> foodRequests)
        {
            List<Food> foods = [];
            foreach (var food in foodRequests)
                foods.Add(food.MapToEntity<Food>());

            await _appDbContext.Set<Food>().AddRangeAsync(foods);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
