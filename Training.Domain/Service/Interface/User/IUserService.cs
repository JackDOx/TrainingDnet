﻿using Training.Domain.Command.Users;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Users;

namespace Training.Domain.Service.Interface.User
{
    public interface IUserService
    {
        Task<bool> CreateAccount(CreateUserCommand request);
        Task<bool> DeleteUser(DeleteUserCommand request);
        Task<AccountViewModel> GetUser(GetUserCommand request);
        //Task<bool> GetMany(DeleteUserCommand request);
        Task<bool> UpdateUser(UpdateUserCommand request);
        Task<PaginationSet<AccountViewModel>> Listing(GetUserPaginationCommand request);
        Task<TokenViewModel> Login(LoginModelCommand request);
    }
}