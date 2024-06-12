using MediatR;
using Training.Domain.Command.Book;
using Training.Domain.Command.Books;
using Training.Domain.Service.Interface.Book;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Books;

namespace Training.Domain.Service.Implementation.Book
{
    public class BookService : IBookService
    {
        private readonly IMediator _mediator;
        public BookService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BookViewModel> CreateBook(CreateBookCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Failed to create new Book!");
            }


        }

        public async Task<bool> DeleteBook(DeleteBookCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<bool> UpdateBook(UpdateBookCommand request)
        {
            return await _mediator.Send(request);

        }

        public async Task<PaginationSet<BookViewModel>> ListingBook(ListingBookCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }

        }
    }
}