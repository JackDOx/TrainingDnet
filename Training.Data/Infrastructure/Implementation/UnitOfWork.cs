using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using Training.Data.Infrastructure.Interfaces;
using Training.Entity.EntityModel;

namespace Training.Data.Infrastructure.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Fields
        private readonly DbContext _dbContext;
       // public DatabaseFacade Database { get; }
        public IDbConnection Connection { get; }
        public virtual IRepository<User> User { get; }
        public virtual IRepository<Role> Role { get; }
        public virtual IRepository<UserDetail> UserDetail { get; }
        public virtual IRepository<UserRole> UserRole { get; }
        public virtual IRepository<Author> Author { get; }
        public virtual IRepository<Category> Category { get; }
        public virtual IRepository<Book> Book { get; }
        public virtual IRepository<ProductRole> ProductRole { get; }

        #endregion

        #region Constructors
        public UnitOfWork(DbContext dbContext,
            //DatabaseFacade database,
            IRepository<User> user,
            IRepository<Role> role,
            IRepository<UserDetail> userDetail,
            IRepository<UserRole> userRole,
            IRepository<Author> author,
            IRepository<Category> category,
            IRepository<Book> book,
            IRepository<ProductRole> productRole
            )

        {
            _dbContext = dbContext;
           // Database = database;
            //Connection = Database.GetDbConnection();
            User = user;
            Role = role;
            UserDetail = userDetail;
            UserRole = userRole;
            Author = author;
            Category = category;
            Book = book;
            ProductRole = productRole;
        }
        #endregion

        #region Methods
        public IDbContextTransaction BeginTransactionScope()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}
