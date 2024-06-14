using Training.Data.Infrastructure.Interfaces;

namespace Training.Domain.Handler.Roles;

public abstract class RoleBaseHandler : BaseHandler
{
    //private readonly string key = UserConstants.Key;
    protected RoleBaseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }
}
