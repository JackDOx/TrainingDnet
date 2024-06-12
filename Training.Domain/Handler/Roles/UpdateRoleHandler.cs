using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Roles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Roles
{
    public class UpdateAuthorHandler : AuthorBaseHandler, IRequestHandler<UpdateAuthorCommand, bool>
    {
        public UpdateAuthorHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.Role.GetById(request.Id);

            if (role == null)
            {
                throw new ArgumentException("No Role found with provided Id!");
            };

            role.RoleName = (request.RoleName == null) ? role.RoleName : request.RoleName;

            _unitOfWork.Role.Update(role);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

