using Training.Domain.Command.ProductRoles;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Books;

namespace Training.Domain.Service.Interface.ProductRole
{
    public interface IProductRoleService
    {
        Task<bool> CreateProductRole(CreateProductRoleCommand request);
        Task<bool> DeleteProductRole(DeleteProductRoleCommand request);
        Task<PaginationSet<ProductRoleViewModel>> ListingProductRole(ListingProductRoleCommand request);
        //Task<bool> GetMany(DeleteUserCommand request);
        Task<bool> UpdateProductRole(UpdateProductRoleCommand request);
    }
}