using MediatR;
using System.ComponentModel.DataAnnotations;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Books;

namespace Training.Domain.Command.ProductRoles
{
    public class ListingProductRoleCommand : IRequest<PaginationSet<ProductRoleViewModel>>
    {
        public List<SearchObjForCondition>? SearchString { get; set; }
        public List<SearchObjForCondition>? Filter { get; set; }
        public SearchObjForCondition? Sort { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class SearchObjForCondition
    {
        public string Field { get; set; }
        public string Value { get; set; }
    }
}

