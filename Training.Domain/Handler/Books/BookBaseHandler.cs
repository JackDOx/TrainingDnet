using Training.Data.Infrastructure.Interfaces;

namespace Training.Domain.Handler.Books;

public abstract class BookBaseHandler : BaseHandler
{
    //private readonly string key = UserConstants.Key;
    protected BookBaseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }
}
