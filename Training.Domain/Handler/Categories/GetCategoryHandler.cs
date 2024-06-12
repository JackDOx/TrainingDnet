using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Categories;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Categories
{
    public class GetCategoryHandler : CategoryBaseHandler, IRequestHandler<GetCategoryCommand, bool>
    {
        public GetCategoryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Category.GetById(request.Id);

            if (author == null)
            {
                throw new ArgumentException("No Author found with provided Id!");
            };


            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

