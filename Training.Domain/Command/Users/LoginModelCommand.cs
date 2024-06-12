using MediatR;
using Training.Domain.ViewModel.Users;

namespace Training.Domain.Command.Users
{
    public class LoginModelCommand :IRequest<TokenViewModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
