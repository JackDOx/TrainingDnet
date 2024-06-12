using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Categories;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Categories
{
    public class DeleteCategoryHandler : CategoryBaseHandler, IRequestHandler<DeleteCategoryCommand, bool>
    {
        public DeleteCategoryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Category.GetById(request.Id);

            if (author == null)
            {
                throw new ArgumentException("No Author found with provided Id!");
            };

            await _unitOfWork.Category.Delete(author);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

