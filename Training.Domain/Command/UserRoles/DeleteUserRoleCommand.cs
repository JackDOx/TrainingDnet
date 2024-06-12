using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.UserRoles
{
    public class DeleteUserRoleCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
