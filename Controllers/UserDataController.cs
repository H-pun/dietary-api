using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Models.Constants;
using Dietary.DataAccess.Models;
using Dietary.DataAccess.Services;

namespace Dietary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserDataController : BaseController<
        CreateUserDataRequest,
        UpdateUserDataRequest,
        DetailUserDataResponse,
        UserData>
    {
        private readonly ILogger<UserDataController> _logger;
        private readonly IUserDataService _service;
        public UserDataController(ILogger<UserDataController> logger, IUserDataService service) : base(service)
        {
            _logger = logger;
            _service = service;
        }

        public override async Task<ActionResult<DetailUserDataResponse>> GetById(Guid id)
        {
            try
            {
                DetailUserDataResponse model = await _baseService.Get<DetailUserDataResponse>(x => x.IdUser == id);
                return new SuccessApiResponse(string.Format(MessageConstant.Success), model);
            }
            catch (HttpRequestException ex)
            {
                return new ErrorApiResponse(ex.Message, statusCode: (int)ex.StatusCode);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
