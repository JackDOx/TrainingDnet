namespace Training.Domain.ViewModel
{
    public class PaginationSet<T>
    {
        public int PageIndex { get; set; }
        public int Count { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
    }
}