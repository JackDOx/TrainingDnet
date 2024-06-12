using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Users;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Users
{
    public class UpdateUserHandler : UserBaseHandler, IRequestHandler<UpdateUserCommand, bool>
    {
        public UpdateUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //var user = await CheckUserExist(request.UserId);
            //if (!user) {
            //    throw new ArgumentException("No User found with that Id to update!"); }

            var toUpdate = await _unitOfWork.User.GetById(request.Id);
            if (toUpdate == null)
            {
                throw new ArgumentException("No User found with that Id to update!");
            }
            // Update user properties
            toUpdate.UserId = (request.UserId != null) ? request.UserId : toUpdate.UserId;
            toUpdate.IsActive = (request.IsActive.HasValue) ? request.IsActive.Value : toUpdate.IsActive;

            var ud = await _unitOfWork.UserDetail.GetOne(x => x.UserId == request.Id);
            if (ud != null)
            {
                ud.FirstName = (request.FirstName != null) ? request.FirstName : ud.FirstName;
                ud.LastName = (request.LastName != null) ? request.LastName : ud.LastName;
                ud.Email = (request.Email != null) ? request.Email : ud.Email;
                ud.Password = (request.Password != null) ? request.Password : ud.Password;
                ud.Address = (request.Address != null) ? request.Address : ud.Address;
                ud.DateOfBirth = (request.DateOfBirth.HasValue) ? request.DateOfBirth.Value : ud.DateOfBirth;
                ud.Gender = (request.Gender != null) ? request.Gender : ud.Gender;
                ud.National = (request.National != null) ? request.National : ud.National;
                ud.NationalId = (request.NationalId != null) ? request.NationalId.Value : ud.NationalId;
                ud.Phone = (request.Phone != null) ? request.Phone : ud.Phone;

                _unitOfWork.UserDetail.Update(ud);
            }

            _unitOfWork.User.Update(toUpdate);

            return await _unitOfWork.CommitAsync() > 0;

        }
    }
}

