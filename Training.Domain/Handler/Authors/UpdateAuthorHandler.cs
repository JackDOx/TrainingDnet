using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Authors;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Authors
{
    public class UpdateCategoryHandler : CategoryBaseHandler, IRequestHandler<UpdateAuthorCommand, bool>
    {
        public UpdateCategoryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Author.GetById(request.Id);

            if (author == null)
            {
                throw new ArgumentException("No Author found with provided Id!");
            };

            author.Name = (request.Name == null) ? author.Name : request.Name;

            _unitOfWork.Author.Update(author);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

