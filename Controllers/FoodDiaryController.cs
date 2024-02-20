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
    public class FoodDiaryController : BaseController<
        CreateFoodDiaryRequest,
        UpdateFoodDiaryRequest,
        DetailFoodDiaryResponse,
        FoodDiary>
    {
        private readonly ILogger<FoodDiaryController> _logger;
        private readonly IFoodDiaryService _service;
        public FoodDiaryController(ILogger<FoodDiaryController> logger, IFoodDiaryService service) : base(service)
        {
            _logger = logger;
            _service = service;
        }

        public override Task<ActionResult> Create([FromForm] CreateFoodDiaryRequest model)
        {
            return base.Create(model);
        }
    }
}