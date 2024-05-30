using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Entity.EntityModel
{
    [Table("User")]
    public class User : EntityBase
    {
        [Required]
        public string UserId { get; set; }
        public virtual UserDetail UserDetails { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
