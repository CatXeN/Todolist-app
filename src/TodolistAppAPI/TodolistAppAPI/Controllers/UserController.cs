using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodolistAppAPI.Authorization;
using TodolistAppDomain.Helper;
using TodolistAppDomain.Identity;
using TodolistAppModels.Informations.Users;

namespace TodolistAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IPermissionAccess _access;
        private readonly IIdentityService _service;

        public UserController(IPermissionAccess access, IIdentityService service)
        {
            _access = access;
            _service = service;
        }

        [Authorize()]
        [HttpGet]  
        public async Task<IActionResult> GetUserSettings()
        {
            int userId = _access.GetUserId();

            try
            {
                var user = await _service.GetUserData(userId);
                return Ok(new GetUserInfo()
                {
                    Username = user.Username,
                    Email = user.Email,
                    Role = EnumHelper.GetDescription(user.Role)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
