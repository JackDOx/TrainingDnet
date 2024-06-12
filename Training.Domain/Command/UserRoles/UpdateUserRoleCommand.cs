using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.UserRoles
{
    public class UpdateUserRoleCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }

        public Guid? RoleId { get; set; }


        public string? RoleName { get; set; }
    }
}
