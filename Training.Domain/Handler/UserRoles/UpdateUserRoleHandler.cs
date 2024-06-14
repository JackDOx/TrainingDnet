using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.UserRoles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Users
{
    public class UpdateUserRoleHandler : UserBaseHandler, IRequestHandler<UpdateUserRoleCommand, bool>
    {
        public UpdateUserRoleHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var userRole = await _unitOfWork.UserRole.GetById(request.Id);

            if (userRole == null)
            {
                throw new ArgumentException("No Role found with provided Id!");
            };

            userRole.RoleId = (request.RoleId.HasValue) ? request.RoleId.Value : userRole.RoleId;
            userRole.UserId = (request.UserId.HasValue) ? request.UserId.Value : userRole.UserId;

            if (request.RoleName != null)
            {
                var role = await _unitOfWork.Role.GetById(userRole.RoleId);
                role.RoleName = request.RoleName;
                _unitOfWork.Role.Update(role);
            }

            _unitOfWork.UserRole.Update(userRole);


            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

