using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Books
{
    public class DeleteBookCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
