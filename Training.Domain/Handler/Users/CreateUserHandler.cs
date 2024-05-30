using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Users;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Users
{
    public class CreateUserHandler : UserBaseHandler, IRequestHandler<CreateUserCommand, bool>
    {
        public CreateUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var checkUser = await CheckUserExist(request.UserId);
            if (checkUser) {
                throw new ArgumentException("Username already exists");
            }

            var id = Guid.NewGuid();
            var user = new User
            {
                Id = id,
                UserId = request.UserId,
                IsActive = true,
            };

            var userDetail = new UserDetail
            {
                UserId = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                FullName = string.Concat(request.FirstName, " ", request.LastName),
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                Gender = request.Gender,
                Password = Encrypt(request.Password),
                Phone = request.Phone,
                National = request.National,
                NationalId = request.NationalId,
            };

            _unitOfWork.User.Insert(user);
            _unitOfWork.UserDetail.Insert(userDetail);
            return await _unitOfWork.CommitAsync() > 0;
            

        }
    }


}
