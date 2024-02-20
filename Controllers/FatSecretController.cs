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
    [Route("[controller]")]
    [ApiController]
    public class FatSecretController : ControllerBase
    {
        private readonly ILogger<FatSecretController> _logger;
        private readonly FatSecretService _fatSecretService;

        public FatSecretController(ILogger<FatSecretController> logger, FatSecretService fatSecretService)
        {
            _logger = logger;
            _fatSecretService = fatSecretService;
        }
        [AllowAnonymous]
        [HttpGet("get-token")]
        public async Task<ActionResult> GetAccessToken()
        {
            return Ok(await _fatSecretService.GetAccessToken());
        }
        [AllowAnonymous]
        [HttpPost("food-search-v2")]
        public async Task<ActionResult> FoodSearchV2(FoodSearchV2Request request)
        {
            return Ok(await _fatSecretService.SearchV2(request));
        }
    }
}
