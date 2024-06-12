using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Authors
{
    public class GetAuthorCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
