using MediatR;
using System.ComponentModel.DataAnnotations;
using Training.Domain.ViewModel.Books;
using Training.Entity.EntityModel;

namespace Training.Domain.Command.Books
{
    public class CreateBookCommand : IRequest<BookViewModel>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string title { get; set; }


        [Required]
        public string Content { get; set; }

        public DateTime? yearOfRelease { get; set; }

        public string? Producer { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Remaining { get; set; }
        public string? Status { get; set; }
    }
}
