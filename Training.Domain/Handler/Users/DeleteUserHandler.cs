using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Users;
using Training.Entity.EntityModel;


namespace Training.Domain.Handler.Users
{
    public class DeleteUserHandler : UserBaseHandler, IRequestHandler<DeleteUserCommand, bool>
    {
        public DeleteUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {


            var user = await _unitOfWork.User.GetById(request.Id);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var userDetail = _unitOfWork.UserDetail.FindAll(ud => ud.UserId == request.Id).ToList();
            if (userDetail == null)
            {
                throw new ArgumentException("UserDetail not found");
            }

            foreach (var ud in userDetail)
            {
                var udDeleted = _unitOfWork.UserDetail.Delete(ud);
            }




            await _unitOfWork.User.Delete(user);

            return await _unitOfWork.CommitAsync() > 0;

        }
    }
}
