using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Authors
{
    public class CreateAuthorCommand : IRequest<bool>
    {
        [Required]
        public string Name { get; set; }
    }
}
