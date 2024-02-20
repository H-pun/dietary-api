using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Models;

namespace Dietary.DataAccess.Services
{
    public interface IUserDataService : IBaseService<UserData>
    {

    }
    public class UserDataService : BaseService<UserData>, IUserDataService
    {
        public UserDataService(AppDbContext appDbContext) : base(appDbContext) { }

    }
}
