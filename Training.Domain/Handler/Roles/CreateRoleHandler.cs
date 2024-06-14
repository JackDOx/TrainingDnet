using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Roles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Roles
{
    public class CreateRoleHandler : RoleBaseHandler, IRequestHandler<CreateRoleCommand, bool>
    {
        public CreateRoleHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var role = new Role
            {
                Id = id,
                RoleName = request.RoleName,
            };

            _unitOfWork.Role.Insert(role);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

