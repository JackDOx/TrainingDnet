using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Roles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Roles
{
    public class DeleteRoleHandler : RoleBaseHandler, IRequestHandler<DeleteRoleCommand, bool>
    {
        public DeleteRoleHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.Role.GetById(request.Id);

            if (role == null)
            {
                throw new ArgumentException("No Role found with provided Id!");
            };

            await _unitOfWork.Role.Delete(role);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

