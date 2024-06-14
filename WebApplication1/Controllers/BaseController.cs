using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Training.Domain.Helper.Constants;

namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public Guid GetCurrentUserId(IHttpContextAccessor _httpContext)
        {
            var identity = _httpContext.HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null) { return Guid.Empty; }
            var userClaim = identity?.Claims.SingleOrDefault(x => x.Type.Equals("Id"));
            return Guid.Parse(userClaim?.Value);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetCurrentUserName(IHttpContextAccessor _httpContext)
        {
            var identity = _httpContext.HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = identity?.Claims.SingleOrDefault(x => x.Type.Equals("Name"));
            return userClaim?.Value;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetCurrentUser(IHttpContextAccessor _httpContext)
        {
            var identity = _httpContext.HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = identity?.Claims.SingleOrDefault(x => x.Type.Equals("UserId"));
            return userClaim?.Value;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetCurrentUserRole(IHttpContextAccessor _httpContext)
        {
            var identity = _httpContext.HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = identity?.Claims.SingleOrDefault(x => x.Type.Equals("Role"));
            //return userClaim?.Value;

            // Get the user's ID from the claims
            string userRole = _httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("Roles"))?.Value;

            return userRole;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public bool RoleAuthenticate(IHttpContextAccessor _httpContext, string pass)
        {
            string role = GetCurrentUserRole(_httpContext);
            string[] uRoles = role.Split(UserConstants.splitter);
            string[] sPasses = pass.Split(UserConstants.splitter);

            foreach (string uRole in uRoles)
            {
                if (sPasses.Contains(uRole))
                {
                    return true;
                }
            }
            return false;
        }
    }
}