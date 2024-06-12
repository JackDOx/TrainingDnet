using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.ProductRoles
{
    public class UpdateProductRoleCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }

        public string? Name {  get; set; }
    }
}
