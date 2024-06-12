using Training.Data.Infrastructure.Interfaces;

namespace Training.Domain.Handler.Categories;

public abstract class CategoryBaseHandler : BaseHandler
{
    //private readonly string key = UserConstants.Key;
    protected CategoryBaseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }
}
