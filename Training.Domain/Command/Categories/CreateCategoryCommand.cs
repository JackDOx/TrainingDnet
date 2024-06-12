using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Categories
{
    public class CreateCategoryCommand : IRequest<bool>
    {
        [Required]
        public string Name { get; set; }
    }
}
