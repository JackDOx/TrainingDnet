using MediatR;
using System.Runtime;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.UserRoles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Roles
{
    public class GetUserRoleHandler : UserRoleBaseHandler, IRequestHandler<GetUserRoleCommand, bool>
    {
        public GetUserRoleHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(GetUserRoleCommand request, CancellationToken cancellationToken)
        {
            var userRole = await _unitOfWork.UserRole.GetById(request.Id);

            if (userRole == null)
            {
                throw new ArgumentException("No Role found with provided Id!");
            };

            var role = await _unitOfWork.Role.GetById(userRole.RoleId);

            if (role != null)
            {
                var result = new
                {
                    userRole,
                    role
                };
            }


            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

