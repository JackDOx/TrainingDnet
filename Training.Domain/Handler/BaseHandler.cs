using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Training.Data.Infrastructure.Interfaces;

namespace Training.Domain.Handler
{
    public abstract class BaseHandler
    {
        private readonly IHttpContextAccessor _httpContext;
        protected readonly IUnitOfWork _unitOfWork;
        public BaseHandler(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }
        public BaseHandler(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Guid GetCurrentUserId()
        {
            var identity = _httpContext.HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = identity?.Claims.SingleOrDefault(x => x.Type.Equals("Id"));
            return Guid.Parse(userClaim?.Value);

        }

        public string GetCurrentUserName()
        {
            var identity = _httpContext.HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = identity?.Claims.SingleOrDefault(x => x.Type.Equals("Name"));
            return userClaim?.Value;
        }

        public string GetCurrentUser()
        {
            var identity = _httpContext.HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = identity?.Claims.SingleOrDefault(x => x.Type.Equals("UserId"));
            return userClaim?.Value;
        }
    }
}
