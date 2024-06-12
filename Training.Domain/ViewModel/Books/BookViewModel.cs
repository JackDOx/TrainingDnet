
using System.ComponentModel.DataAnnotations;
using Training.Entity.EntityModel;

namespace Training.Domain.ViewModel.Books
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string title { get; set; }

        public string Content { get; set; }

        public DateTime yearOfRelease { get; set; }

        public string Producer { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }
        public int Remaining { get; set; }
        public string Status { get; set; }

    }

    public class ProductRoleViewModel
    {
        public Guid BookId { get; set; }
        public string ListRole { get; set; }
    }
}
