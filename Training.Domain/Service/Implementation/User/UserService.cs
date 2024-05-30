using MediatR;
using Training.Domain.Command.Users;
using Training.Domain.Service.Interface.User;

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
    }
}
