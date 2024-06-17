using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Users;
using Training.Domain.ViewModel.Users;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Users
{
    public class GetUserHandler : UserBaseHandler, IRequestHandler<GetUserCommand, AccountViewModel> {
        public GetUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<AccountViewModel> Handle(GetUserCommand request, CancellationToken cancellationToken) {
            var user = await _unitOfWork.User.GetById(request.Id);
            if (user == null) {
                throw new ArgumentException("No User found!");
            }

            var userDetail = await _unitOfWork.UserDetail.GetOne(ud => ud.UserId == request.Id);
            
                var result = new AccountViewModel
                {
                    Id = user.Id,
                    UserId = user.UserId,
                    Email = userDetail.Email,
                    FullName = userDetail.FullName,
                    Address = userDetail.Address,
                    PhoneNumber = userDetail.Phone,
                    Roles = user.UserRoles
                    .Select(r => new RoleViewModel
                    {
                        Id = r.Role.Id,
                        Name = r.Role.RoleName
                    }).ToList(),
                    DateOfBirth = userDetail.DateOfBirth,
                    Gender = userDetail.Gender,
                    National = userDetail.National,
                    NationalId = userDetail.NationalId,
                };
            
            // Concat 2 objects into an anonymous object for return


            return result;


        }

    }
}
