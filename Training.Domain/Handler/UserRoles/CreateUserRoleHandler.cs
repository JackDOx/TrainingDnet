using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.UserRoles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Roles
{
    public class CreateUserRoleHandler : UserRoleBaseHandler, IRequestHandler<CreateUserRoleCommand, bool>
    {
        public CreateUserRoleHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var role = await _unitOfWork.Role.GetById(request.RoleId);
            if (role == null)
            {
                throw new ArgumentException("No role found with that ID!"); 
            }
            var UserRole = new UserRole
            {
                RoleId = request.RoleId,
                UserId = request.UserId,
            };

            _unitOfWork.UserRole.Insert(UserRole);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

