using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Authors
{
    public class DeleteAuthorCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
