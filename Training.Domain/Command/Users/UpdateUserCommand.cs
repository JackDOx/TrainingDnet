using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Command.Users
{
    public class UpdateUserCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public String? FirstName { get; set; }

        public String? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? NationalId { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Password { get; set; }
        public string? Phone { get; set; }

        public string? Gender { get; set; }

        public string? National { get; set; }

        public bool? IsActive { get; set; }
    }
}
