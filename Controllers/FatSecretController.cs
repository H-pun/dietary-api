using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.DataAccess.Models.Constants;
using Dietary.DataAccess.Models;
using Dietary.DataAccess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<AccessTokenResponse>> GetAccessToken()
        {
            try
            {
                var token = await _service.GetAccessToken();
                return new SuccessApiResponse(string.Format(MessageConstant.Success), token);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        [HttpPost("food-search-v2")]
        public async Task<ActionResult<FoodSearchV2Response>> FoodSearchV2(FoodSearchV2Request request)
        {
            try
            {
                var searchResult = await _service.SearchV2(request);
                return new SuccessApiResponse(string.Format(MessageConstant.Success), searchResult);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        [HttpPost("food-search-v2-seeding")]
        public async Task<ActionResult<FoodSearchSeedingResponse>> FoodSearchV2Seeding(FoodSearchV2Request request)
        {
            try
            {
                FoodSearchV2Response searchResponse = await _service.SearchV2(request);
                FoodSearchSeedingResponse seedingResponse = new(searchResponse)
                {
                    TotalDataInserted = await _service.BulkInsert(searchResponse)
                };
                return new SuccessApiResponse(string.Format(MessageConstant.Success), seedingResponse);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        [HttpPost("scrap")]
        public async Task<ActionResult> Scrap(string url)
        {
            try
            {
                var scrappedData = await _service.Scrap(new() { Url = url });
                return new SuccessApiResponse(string.Format(MessageConstant.Success), scrappedData);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        [HttpGet("name/{name}")]
        public ActionResult<List<DetailFatSecretResponse>> GetByName(string name)
        {
            try
            {
                List<DetailFatSecretResponse> models = _baseService.GetAll<DetailFatSecretResponse>(x => EF.Functions.ILike(x.FoodName, $"%{name}%") && x.FoodType == "Generic");
                return new SuccessApiResponse(string.Format(MessageConstant.Success), models);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
