using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Models;

namespace Dietary.DataAccess.Services
{
    public interface IUserDataService : IBaseService<UserData>
    {

    }
    public class UserDataService(AppDbContext appDbContext) : BaseService<UserData>(appDbContext), IUserDataService
    {
    }
}
