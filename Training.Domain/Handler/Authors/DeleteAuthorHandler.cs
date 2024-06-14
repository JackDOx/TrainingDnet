using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Authors;


namespace Training.Domain.Handler.Authors
{
    public class DeleteAuthorHandler : AuthorBaseHandler, IRequestHandler<DeleteAuthorCommand, bool>
    {
        public DeleteAuthorHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Author.GetById(request.Id);

            if (author == null)
            {
                throw new ArgumentException("No Author found with provided Id!");
            };

            await _unitOfWork.Author.Delete(author);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

