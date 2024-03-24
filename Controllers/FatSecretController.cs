using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Models.Constants;
using Dietary.DataAccess.Models;
using Dietary.DataAccess.Services;
using Microsoft.AspNetCore.Authorization;

namespace Dietary.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class FatSecretController(ILogger<FatSecretController> logger, FatSecretService fatSecretService, IFoodService foodService) : ControllerBase
    {
        private readonly ILogger<FatSecretController> _logger = logger;
        private readonly FatSecretService _fatSecretService = fatSecretService;
        private readonly IFoodService _foodService = foodService;

        [HttpGet("get-token")]
        public async Task<ActionResult> GetAccessToken()
        {
            return Ok(await _fatSecretService.GetAccessToken());
        }
        [HttpPost("food-search-v2")]
        public async Task<ActionResult> FoodSearchV2(FoodSearchV2Request request)
        {
            return Ok(await _fatSecretService.SearchV2(request));
        }
        [HttpPost("scrap")]
        public async Task<ActionResult> Scrap(string url)
        {
            return Ok(await _fatSecretService.Scrap(new() { Url = url }));
        }
    }
}
