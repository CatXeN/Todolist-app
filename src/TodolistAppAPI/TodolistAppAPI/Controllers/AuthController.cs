using Microsoft.AspNetCore.Mvc;
using TodolistAppDomain.Identity;
using TodolistAppModels.Informations;

namespace TodolistAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IIdentityService _service;

        public AuthController(IIdentityService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserInformation userInformation)
        {
            userInformation.Username = userInformation.Username.ToLower();

            try
            {
                await _service.CreateUser(userInformation);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return new JsonResult("The account has been created successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginInformation userInformation)
        {
            string token;

            try
            {
                token = await _service.GetToken(userInformation.Username, userInformation.Password);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            return new JsonResult(token);
        }
    }
}
