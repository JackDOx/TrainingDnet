using MediatR;
using Training.Domain.Command.ProductRoles;
using Training.Domain.Service.Interface.ProductRole;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Books;

namespace Training.Domain.Service.Implementation.ProductRole
{
    public class ProductRoleService : IProductRoleService
    {
        private readonly IMediator _mediator;
        public ProductRoleService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> CreateProductRole(CreateProductRoleCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> DeleteProductRole(DeleteProductRoleCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> UpdateProductRole(UpdateProductRoleCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<PaginationSet<ProductRoleViewModel>> ListingProductRole(ListingProductRoleCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            } catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
            

        }
    }
}