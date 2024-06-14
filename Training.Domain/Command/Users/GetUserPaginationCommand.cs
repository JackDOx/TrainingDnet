using MediatR;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Users;

namespace Training.Domain.Command.Users
{
    public class GetUserPaginationCommand : IRequest<PaginationSet<AccountViewModel>>
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