using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Book;
using Training.Domain.Command.Books;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Books
{
    public class ListingBookHandler : BookBaseHandler, IRequestHandler<ListingBookCommand, bool>
    {
        public ListingBookHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

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

