using MediatR;
using System.ComponentModel.DataAnnotations;


namespace Training.Domain.Command.Users
{
    public class DeleteUserCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }

}
