using Training.Domain.Command.Users;

namespace Training.Domain.Service.Interface.User
{
    public interface IUserService
    {
        Task<bool> CreateAccount(CreateUserCommand request);
    }
}