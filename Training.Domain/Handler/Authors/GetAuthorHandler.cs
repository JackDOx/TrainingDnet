using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Authors;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Authors
{
    public class GetCategoryHandler : CategoryBaseHandler, IRequestHandler<GetAuthorCommand, bool>
    {
        public GetCategoryHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(GetAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Author.GetById(request.Id);

            if (author == null)
            {
                throw new ArgumentException("No Author found with provided Id!");
            };


            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

