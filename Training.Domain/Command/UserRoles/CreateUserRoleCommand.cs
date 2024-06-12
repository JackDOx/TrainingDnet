using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.UserRoles
{
    public class CreateUserRoleCommand : IRequest<bool>
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid RoleId { get; set; }
    }
}
