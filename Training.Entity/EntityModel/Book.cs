using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Entity.EntityModel
{
    [Table("Book")]
    public class Book : EntityBase
    {
        [Required]
        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string title { get; set; }


        [Required]
        public string Content { get; set; }

        public DateTime? yearOfRelease { get; set; }

        public string? Producer { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Remaining { get; set; }
        public string? Status { get; set; }



    }
}
