using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Authors;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Categories
{
    public class UpdateCategoryHandler : CategoryBaseHandler, IRequestHandler<UpdateAuthorCommand, bool>
    {
        public UpdateCategoryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var cat = await _unitOfWork.Category.GetById(request.Id);

            if (cat == null)
            {
                throw new ArgumentException("No Author found with provided Id!");
            };

            cat.Name = (request.Name == null) ? cat.Name : request.Name;

            _unitOfWork.Category.Update(cat);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

