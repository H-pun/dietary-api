using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Models;

namespace Dietary.DataAccess.Services
{
    public interface IFoodDiaryService : IBaseService<FoodDiary>
    {

    }
    public class FoodDiaryService : BaseService<FoodDiary>, IFoodDiaryService
    {
        public FoodDiaryService(AppDbContext appDbContext) : base(appDbContext) { }

    }
}
