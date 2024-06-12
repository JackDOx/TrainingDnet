using Training.Domain.Command.Categories;

namespace Training.Domain.Service.Interface.Category
{
    public interface ICategoryService
    {
        Task<bool> CreateCategory(CreateCategoryCommand request);
        Task<bool> DeleteCategory(DeleteCategoryCommand request);
        Task<bool> GetCategory(GetCategoryCommand request);
        //Task<bool> GetMany(DeleteUserCommand request);
        Task<bool> UpdateCategory(UpdateCategoryCommand request);
    }
}