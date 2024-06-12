using MediatR;
using Training.Domain.Command.UserRoles;
using Training.Domain.Service.Interface.UserRole;

namespace Training.Domain.Service.Implementation.UserRole
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IMediator _mediator;
        public UserRoleService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> CreateUserRole(CreateUserRoleCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> DeleteUserRole(DeleteUserRoleCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> UpdateUserRole(UpdateUserRoleCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> GetUserRole(GetUserRoleCommand request)
        {
            return await _mediator.Send(request);

        }
    }
}