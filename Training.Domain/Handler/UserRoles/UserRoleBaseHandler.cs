using System.Security.Cryptography;
using System.Text;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Helper.Constants;

namespace Training.Domain.Handler.Roles;

public abstract class UserRoleBaseHandler : BaseHandler
{
    //private readonly string key = UserConstants.Key;
    protected UserRoleBaseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }
}
