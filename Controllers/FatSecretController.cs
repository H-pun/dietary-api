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
    public class FatSecretController(ILogger<FatSecretController> logger, IFatSecretService service) : BaseController<
        CreateFatSecretRequest,
        UpdateFatSecretRequest,
        DetailFatSecretResponse,
        FatSecretFood>(service)
    {
        private readonly ILogger<FatSecretController> _logger = logger;
        private readonly IFatSecretService _service = service;

        [HttpGet("get-token")]
        public async Task<ActionResult> GetAccessToken()
        {
            return Ok(await _service.GetAccessToken());
        }
        [HttpPost("food-search-v2")]
        public async Task<ActionResult> FoodSearchV2(FoodSearchV2Request request)
        {
            return Ok(await _service.SearchV2(request));
        }
        [HttpPost("food-search-v2-seeding")]
        public async Task<ActionResult> FoodSearchV2Seeding(FoodSearchV2Request request)
        {
            FoodSearchV2Response response = await _service.SearchV2(request);
            await _service.BulkInsert(response);
            return Ok(response);
        }
        [HttpPost("scrap")]
        public async Task<ActionResult> Scrap(string url)
        {
            return Ok(await _service.Scrap(new() { Url = url }));
        }
    }
}
