using Training.Domain.Command.Books;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Books;

namespace Training.Domain.Service.Interface.Book
{
    public interface IBookService
    {
        Task<BookViewModel> CreateBook(CreateBookCommand request);
        Task<bool> DeleteBook(DeleteBookCommand request);
        Task<PaginationSet<BookViewModel>> ListingBook(ListingBookCommand request);
        //Task<bool> GetMany(DeleteUserCommand request);
        Task<bool> UpdateBook(UpdateBookCommand request);
    }
}