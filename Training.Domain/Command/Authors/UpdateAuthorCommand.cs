using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Authors
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }

        public string? Name {  get; set; }
    }
}
