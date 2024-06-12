using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Users;
using Training.Entity.EntityModel;

namespace Training.Domain.Handler.Users
{
    public class GetUserHandler : UserBaseHandler, IRequestHandler<GetUserCommand, bool> {
        public GetUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<bool> Handle(GetUserCommand request, CancellationToken cancellationToken) {
            var user = _unitOfWork.User.GetById(request.Id);
            if (user == null) {
                throw new ArgumentException("No User found!");
            }

            var userDetail = _unitOfWork.User.FindAll(x => x.UserId == request.Id.ToString()).ToList();
            if (userDetail == null) { 
            }
            
            // Concat 2 objects into an anonymous object for return
            var result = new
            {
                user,
                userDetail

            };

            return await _unitOfWork.CommitAsync() > 0;


        }

    }
}
