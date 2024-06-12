using MediatR;
using Training.Domain.Command.Categories;
using Training.Domain.Service.Interface.Category;

namespace Training.Domain.Service.Implementation.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediator _mediator;
        public CategoryService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> CreateCategory(CreateCategoryCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> DeleteCategory(DeleteCategoryCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> UpdateCategory(UpdateCategoryCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> GetCategory(GetCategoryCommand request)
        {
            return await _mediator.Send(request);

        }
    }
}