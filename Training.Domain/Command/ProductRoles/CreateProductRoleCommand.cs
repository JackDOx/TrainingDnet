using MediatR;
using System.ComponentModel.DataAnnotations;
using Training.Entity.EntityModel;

namespace Training.Domain.Command.ProductRoles
{
    public class CreateProductRoleCommand : IRequest<bool>
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        public string ListRole { get; set; }
    }
}
