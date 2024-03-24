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
    public class FoodDiaryController(ILogger<FoodDiaryController> logger, IFoodDiaryService service) : BaseController<
        CreateFoodDiaryRequest,
        UpdateFoodDiaryRequest,
        DetailFoodDiaryResponse,
        FoodDiary>(service)
    {
        private readonly ILogger<FoodDiaryController> _logger = logger;
        private readonly IFoodDiaryService _service = service;

        [HttpGet("user")]
        public virtual ActionResult<List<DetailFoodDiaryResponse>> GetByIdUser(Guid idUser, DateTime? date)
        {
            try
            {
                List<DetailFoodDiaryResponse> model = _baseService.GetAll<DetailFoodDiaryResponse>(x => x.IdUser == idUser && (!date.HasValue || x.AddedAt.Date == date.Value.Date));
                return new SuccessApiResponse(string.Format(MessageConstant.Success), model);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        public override Task<ActionResult> Create([FromForm] CreateFoodDiaryRequest model)
        {
            return base.Create(model);
        }
    }
}
