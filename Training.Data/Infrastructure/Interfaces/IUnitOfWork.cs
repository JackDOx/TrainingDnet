using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using Training.Entity.EntityModel;

namespace Training.Data.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IDbConnection Connection { get; }
       // DatabaseFacade Database { get; }
        #region Repositories
        IRepository<User> User { get; }
        IRepository<Role> Role { get; }
        IRepository<UserDetail> UserDetail { get; }
        IRepository<UserRole> UserRole { get; }
        IRepository<Author> Author { get; }
        IRepository<Category> Category { get; }
        IRepository<Book> Book { get; }
        IRepository<ProductRole> ProductRole { get; }
        #endregion

        #region Methods
        int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
        IDbContextTransaction BeginTransactionScope();  
        #endregion
    }
    
}
