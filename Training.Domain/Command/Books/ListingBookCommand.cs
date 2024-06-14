using MediatR;
using System.ComponentModel.DataAnnotations;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Books;
using Training.Domain.Command.Users;
using System.Text.Json.Serialization;

namespace Training.Domain.Command.Books
{
    public class ListingBookCommand : IRequest<PaginationSet<BookViewModel>>
    {
        public List<SearchObjForCondition>? SearchString { get; set; }
        public List<SearchObjForCondition>? Filter { get; set; }
        public SearchObjForCondition? Sort { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        [JsonIgnore]
        public string? userRole { get; set; } = null;
    }

}

