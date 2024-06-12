using MediatR;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Users;
using Training.Domain.Extensions;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Users;


namespace Training.Domain.Handler.Users
{
    public class ListingUserHandler : UserBaseHandler, IRequestHandler<GetUserPaginationCommand, PaginationSet<BookViewModel>> 
    {
        public ListingUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<PaginationSet<BookViewModel>> Handle(GetUserPaginationCommand request, CancellationToken cancellationToken)
        {
            var roles = _unitOfWork.Role.GetQueryable();
            var query = _unitOfWork.User.GetQueryable()
                .Select(x => new BookViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
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

                });
            
            if (request.Filter != null)
            {
                query = query.Filter(request.Filter);
            }

            if (request.SearchString != null)
            {
                query = query.Search(request.SearchString);
            }
            //var x = ((IQueryable) query).expression;

            var result = await query.Pagination(request.PageIndex, request.PageSize, request.Sort);
            return result;
        }

    }


}
