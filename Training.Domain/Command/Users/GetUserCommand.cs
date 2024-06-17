using MediatR;
using System.ComponentModel.DataAnnotations;
using Training.Domain.ViewModel.Users;

namespace Training.Domain.Command.Users
{
    public class GetUserCommand : IRequest<AccountViewModel> {
        [Required]
        public Guid Id { get; set; }
    }
}
