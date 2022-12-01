using System.IdentityModel.Tokens.Jwt;
using System.Web;
using TodolistAppAPI.Authorization;

namespace TodolistAppAPI.Factories
{
    public class PermissionAccess : IPermissionAccess
    {
        IHttpContextAccessor _httpContextAccessor;

        public PermissionAccess(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {
            if (_httpContextAccessor.HttpContext == null)
                return 0;

            var auth = _httpContextAccessor.HttpContext.Request.Headers["authorization"];
            var token = auth.ToString().Split(" ")[1];

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var nameId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid");

            if (nameId == null)
                return 0;

            return int.Parse(nameId.Value);
        }
    }
}
