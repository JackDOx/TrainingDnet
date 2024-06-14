using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Roles
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
