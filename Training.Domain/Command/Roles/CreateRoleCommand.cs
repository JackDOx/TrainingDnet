using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Roles
{
    public class CreateRoleCommand : IRequest<bool>
    {
        [Required]
        public string RoleName { get; set; }
    }
}
