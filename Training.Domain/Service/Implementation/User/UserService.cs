using MediatR;
using Training.Domain.Command.Users;
using Training.Domain.Service.Interface.User;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Users;

namespace Training.Domain.Service.Implementation.User
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> CreateAccount(CreateUserCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> DeleteUser(DeleteUserCommand request)
        {
            return await _mediator.Send(request);
        }

        public async Task<AccountViewModel> GetUser(GetUserCommand request)
        {
            return await _mediator.Send(request);
        }

        public async Task<PaginationSet<AccountViewModel>> Listing(GetUserPaginationCommand request)
        {
            try
            {
                return await _mediator.Send(request);

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
        }

        public async Task<TokenViewModel> Login(LoginModelCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
        }

        public async Task<bool> UpdateUser(UpdateUserCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
