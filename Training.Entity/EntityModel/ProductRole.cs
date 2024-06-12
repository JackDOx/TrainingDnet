using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Entity.EntityModel
{
    [Table("ProductRole")]
    public class ProductRole : EntityBase
    {
        [Required]
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        [Required]
        public string ListRole {  get; set; }


    }
}
