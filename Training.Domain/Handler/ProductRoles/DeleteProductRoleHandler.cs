using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.ProductRoles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.ProductRoles
{
    public class DeleteProductRoleHandler : ProductRoleBaseHandler, IRequestHandler<DeleteProductRoleCommand, bool>
    {
        public DeleteProductRoleHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(DeleteProductRoleCommand request, CancellationToken cancellationToken)
        {
            var pd = await _unitOfWork.ProductRole.GetById(request.Id);

            if (pd == null)
            {
                throw new ArgumentException("No ProductRole found with provided Id!");
            };

            await _unitOfWork.ProductRole.Delete(pd);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

