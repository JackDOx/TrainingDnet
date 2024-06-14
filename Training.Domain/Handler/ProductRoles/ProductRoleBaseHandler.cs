using Training.Data.Infrastructure.Interfaces;

namespace Training.Domain.Handler.ProductRoles;

public abstract class ProductRoleBaseHandler : BaseHandler
{
    //private readonly string key = UserConstants.Key;
    protected ProductRoleBaseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }
}
