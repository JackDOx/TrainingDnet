using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.ProductRoles
{
    public class DeleteProductRoleCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
