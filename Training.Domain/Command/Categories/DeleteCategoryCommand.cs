using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Categories
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
