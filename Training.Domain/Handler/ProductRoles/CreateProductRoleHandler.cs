using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.ProductRoles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.ProductRoles
{
    public class CreateProductRoleHandler : ProductRoleBaseHandler, IRequestHandler<CreateProductRoleCommand, bool>
    {
        public CreateProductRoleHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(CreateProductRoleCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var pr = new ProductRole
            {
                Id = id,
                BookId = request.BookId,
                ListRole = request.ListRole,
            };

            _unitOfWork.ProductRole.Insert(pr);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

