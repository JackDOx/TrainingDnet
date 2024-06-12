using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Books;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Books
{
    public class UpdateBookHandler : BookBaseHandler, IRequestHandler<UpdateBookCommand, bool>
    {
        public UpdateBookHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Book.GetById(request.Id);

            if (book == null)
            {
                throw new ArgumentException("No Book found with provided Id!");
            };

            book.AuthorId = (request.AuthorId.HasValue) ? request.AuthorId.Value : book.AuthorId;
            book.CategoryId = (request.CategoryId.HasValue) ? request.CategoryId.Value : book.CategoryId;
            book.Name = (request.Name != null) ? request.Name : book.Name;
            book.title = (request.title != null) ? request.title : book.title;
            book.Content = (request.Content != null) ? request.Content : book.Content;
            book.yearOfRelease = (request.yearOfRelease.HasValue) ? request.yearOfRelease.Value : book.yearOfRelease;
            book.Producer = (request.Producer != null) ? request.Producer : book.Producer;
            book.Quantity = (request.Quantity.HasValue) ? request.Quantity.Value : book.Quantity;
            book.Price = (request.Price != null) ? request.Price.Value : book.Price;
            book.Remaining = (request.Remaining.HasValue) ? request.Remaining.Value : book.Remaining;
            book.Status = (request.Status != null) ? request.Status : book.Status;

            _unitOfWork.Book.Update(book);

            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}

