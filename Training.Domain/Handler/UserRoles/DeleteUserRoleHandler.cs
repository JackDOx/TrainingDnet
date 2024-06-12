using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.UserRoles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Roles
{
    public class DeleteUserRoleHandler : UserRoleBaseHandler, IRequestHandler<DeleteUserRoleCommand, bool>
    {
        public DeleteUserRoleHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            var userRole = await _unitOfWork.UserRole.GetById(request.Id);

            if (userRole == null)
            {
                throw new ArgumentException("No Role found with provided Id!");
            };

            var role = _unitOfWork.Role.GetById(userRole.RoleId);

            if (role != null)
            {
                await _unitOfWork.Role.Delete(role);
            }

            await _unitOfWork.UserRole.Delete(userRole);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

