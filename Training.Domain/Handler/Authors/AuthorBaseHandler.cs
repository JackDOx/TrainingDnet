using Training.Data.Infrastructure.Interfaces;

namespace Training.Domain.Handler.Authors;

public abstract class AuthorBaseHandler : BaseHandler
{
    //private readonly string key = UserConstants.Key;
    protected AuthorBaseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }
}
