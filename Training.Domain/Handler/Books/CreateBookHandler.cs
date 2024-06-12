using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Books;
using Training.Domain.ViewModel.Books;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Books
{
    public class CreateBookHandler : BookBaseHandler, IRequestHandler<CreateBookCommand, BookViewModel>
    {
        public CreateBookHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<BookViewModel> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var book = new Book
            {
                Id = id,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                Name = request.Name,
                title = request.title,
                Content = request.Content,
                yearOfRelease = request.yearOfRelease,
                Producer = request.Producer,
                Quantity = request.Quantity,
                Price = request.Price,
                Remaining = request.Remaining,
                Status = request.Status

            };

            _unitOfWork.Book.Insert(book);

            if ( await _unitOfWork.CommitAsync() <= 0)
            {
                return null;
            }

            var ou = new BookViewModel
            {
                Id = id,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                Name = request.Name,
                title = request.title,
                Content = request.Content,
                yearOfRelease = request.yearOfRelease.Value,
                Producer = request.Producer,
                Quantity = request.Quantity,
                Price = request.Price,
                Remaining = request.Remaining,
                Status = request.Status
            };


            return ou;
        }
    }
}

