using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Categories;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Categories
{
    public class CreateCategoryHandler : CategoryBaseHandler, IRequestHandler<CreateCategoryCommand, bool>
    {
        public CreateCategoryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var cat = new Category
            {
                Id = id,
                Name = request.Name,
            };

            _unitOfWork.Category.Insert(cat);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

