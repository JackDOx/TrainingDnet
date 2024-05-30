using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Users
{
    public class CreateUserCommand : IRequest<bool>
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int NationalId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string National { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
