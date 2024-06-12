using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Categories
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }

        public string? Name {  get; set; }
    }
}
