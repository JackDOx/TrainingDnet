using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Roles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Roles
{
    public class DeleteAuthorHandler : AuthorBaseHandler, IRequestHandler<DeleteAuthorCommand, bool>
    {
        public DeleteAuthorHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
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

