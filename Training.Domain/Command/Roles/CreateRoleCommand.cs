using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Roles
{
    public class CreateBookCommand : IRequest<bool>
    {
        [Required]
        public string RoleName { get; set; }
    }
}
