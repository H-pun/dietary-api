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
    public class UserController : BaseController<
        RegisterUserRequest,
        UpdateUserRequest,
        DetailUserResponse,
        User>
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;
        private readonly FatSecretService _fatSecretService;
        
        public UserController(ILogger<UserController> logger, IUserService service, FatSecretService fatSecretService) : base(service)
        {
            _logger = logger;
            _service = service;
            _fatSecretService = fatSecretService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                object result = await _service.Login(loginRequest.Username, loginRequest.Password);
                return new SuccessApiResponse(string.Format(MessageConstant.Success), result);
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
        [HttpPost("change-password")]
        public async Task<ActionResult> ChengePassword(ChangePasswordRequest model)
        {
            try
            {
                await _service.ChangePassword(model);
                return new SuccessApiResponse(string.Format(MessageConstant.Success), "Success");
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
        [AllowAnonymous]
        [HttpPost("register")]
        public override Task<ActionResult> Create(RegisterUserRequest model)
        {
            return base.Create(model);
        }
        [AllowAnonymous]
        [HttpGet("test")]
        public async Task<ActionResult> Test()
        {

            return Ok(await _fatSecretService.GetAccessToken());
        }
    }
}
