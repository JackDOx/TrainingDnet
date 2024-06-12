using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.UserRoles
{
    public class GetUserRoleCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
