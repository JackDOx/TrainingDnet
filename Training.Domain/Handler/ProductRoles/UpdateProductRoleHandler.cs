using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.ProductRoles;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.ProductRoles
{
    public class UpdateProductRoleHandler : ProductRoleBaseHandler, IRequestHandler<UpdateProductRoleCommand, bool>
    {
        public UpdateProductRoleHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(UpdateProductRoleCommand request, CancellationToken cancellationToken)
        {
            var pd = await _unitOfWork.ProductRole.GetById(request.Id);

            if (pd == null)
            {
                throw new ArgumentException("No ProductRole found with provided Id!");
            };

            pd.BookId = (request.BookId == null) ? pd.BookId : request.BookId.Value;
            pd.ListRole = (request.ListRole == null) ? pd.ListRole : request.ListRole;

            _unitOfWork.ProductRole.Update(pd);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

