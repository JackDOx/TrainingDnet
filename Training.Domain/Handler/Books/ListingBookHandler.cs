using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Training.Data.Infrastructure.Interfaces;
using Training.Domain.Command.Books;
using Training.Domain.Extensions;
using Training.Domain.Helper.Constants;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Books;

namespace Training.Domain.Handler.Books
{
    public class ListingBookHandler : BookBaseHandler, IRequestHandler<ListingBookCommand, PaginationSet<BookViewModel>>
    {
        public ListingBookHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<PaginationSet<BookViewModel>> Handle(ListingBookCommand request, CancellationToken cancellationToken)
        {
            var roles = _unitOfWork.ProductRole.GetQueryable()
                .Where(r => (r == null) ? true : r.ListRole.Contains(request.userRole));

            var query = _unitOfWork.Book.GetQueryable()
                .Where(x => /*
                     (roles
                    .Where(r => r.BookId == x.Id)
                    .Select(r => r.ListRole)
                    //.Contains(request.userRole))
                    .Any(roleList => roleList == null ? true : (roleList.Split(", ", System.StringSplitOptions.None).Contains(request.userRole)))))
                */
                roles.Any(r => r.BookId == x.Id))
                .Select(x => new BookViewModel
                {
                    Id = x.Id,
                    AuthorId = x.AuthorId,
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    title = x.title,
                    Content = x.Content,
                    yearOfRelease = x.yearOfRelease.Value,
                    Producer = x.Producer,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Remaining = x.Remaining,
                    Status = x.Status,
                    RoleAccess = string.Join(UserConstants.splitter, roles
                        .Where(r => r.BookId == x.Id) // Match BookId with x.Id
                        .Select(r => r.ListRole))

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

