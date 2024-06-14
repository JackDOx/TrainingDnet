using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.ProductRoles;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Books;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.ProductRoles
{
    public class GetProductRoleHandler : ProductRoleBaseHandler, IRequestHandler<ListingProductRoleCommand, PaginationSet<ProductRoleViewModel>>
    {
        public GetProductRoleHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<PaginationSet<ProductRoleViewModel>> Handle(ListingProductRoleCommand request, CancellationToken cancellationToken)
        {
            /*
            var author = await _unitOfWork.ProductRole.GetById(request.Id);

            if (author == null)
            {
                throw new ArgumentException("No Author found with provided Id!");
            };
            */


            return null;
        }
    }
}

