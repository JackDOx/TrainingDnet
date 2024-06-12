using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Books;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Books
{
    public class DeleteBookHandler : BookBaseHandler, IRequestHandler<DeleteBookCommand, bool>
    {
        public DeleteBookHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Book.GetById(request.Id);

            if (author == null)
            {
                throw new ArgumentException("No Book found with provided Id!");
            };

            await _unitOfWork.Book.Delete(author);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

