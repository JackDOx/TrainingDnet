using MediatR;
using Training.Domain.Command.Roles;
using Training.Domain.Service.Interface.Role;

namespace Training.Domain.Service.Implementation.Role
{
    public class RoleService : IRoleService
    {
        private readonly IMediator _mediator;
        public RoleService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> CreateRole(CreateRoleCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> DeleteRole(DeleteRoleCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> UpdateRole(UpdateRoleCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> GetRole(GetRoleCommand request)
        {
            return await _mediator.Send(request);

        }
    }
}