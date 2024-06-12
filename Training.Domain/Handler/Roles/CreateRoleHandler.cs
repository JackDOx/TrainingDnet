using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Roles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Roles
{
    public class CreateAuthorHandler : AuthorBaseHandler, IRequestHandler<CreateBookCommand, bool>
    {
        public CreateAuthorHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(CreateBookCommand request, CancellationToken cancellationToken)
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

