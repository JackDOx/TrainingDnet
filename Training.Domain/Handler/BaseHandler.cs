using Microsoft.AspNetCore.Http;
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
    }
}
