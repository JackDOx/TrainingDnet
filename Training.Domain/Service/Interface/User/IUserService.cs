using Training.Domain.Command.Users;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Users;

namespace Training.Domain.Service.Interface.User
{
    public interface IUserService
    {
        Task<bool> CreateAccount(CreateUserCommand request);
        Task<bool> DeleteUser(DeleteUserCommand request);
        Task<bool> GetUser(GetUserCommand request);
        //Task<bool> GetMany(DeleteUserCommand request);
        Task<bool> UpdateUser(UpdateUserCommand request);
        Task<PaginationSet<BookViewModel>> Listing(GetUserPaginationCommand request);
        Task<TokenViewModel> Login(LoginModelCommand request);
    }
}