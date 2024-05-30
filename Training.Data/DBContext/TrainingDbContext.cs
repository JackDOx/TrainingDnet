using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Entity.EntityModel;

namespace Training.Data.DBContext
{
    public class TrainingDbContext : DbContext
    {
        public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
