using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Users;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Users;

namespace Training.Domain.Handler.Users
{
    public class LoginHandler : UserBaseHandler, IRequestHandler<LoginModelCommand, TokenViewModel>
    {
        public LoginHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<TokenViewModel> Handle(LoginModelCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.User.GetQueryable(X => X.UserId == request.Username)
                .Select(x => new AccountViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Password = x.UserDetails.Password,
                    Email = x.UserDetails.Email,
                    FullName = x.UserDetails.FullName,
                    Address = x.UserDetails.Address,
                    PhoneNumber = x.UserDetails.Phone,
                    Roles = x.UserRoles
                    .Select(r => new RoleViewModel
                    {
                        Id = r.Role.Id,
                        Name = r.Role.RoleName
                    }).ToList(),
                    DateOfBirth = x.UserDetails.DateOfBirth,
                    Gender = x.UserDetails.Gender,
                    National = x.UserDetails.National,
                    NationalId = x.UserDetails.NationalId,

                }).FirstOrDefaultAsync();

            if (account == null)
            {
                throw new ArgumentException("Username does not exist!");
            }

            if (account.Password != Encrypt(request.Password))
            {
                throw new ArgumentException("Wrong password!");
            }

            account.Password = Decrypt(account.Password);

            var token = new TokenViewModel();
            token.UserProfile = account;

            return token;

        }
    }
}
