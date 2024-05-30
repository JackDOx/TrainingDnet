using System.Data.SqlClient;
using System.Linq.Expressions;
using Training.Data.Core;

namespace Training.Data.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        #region Methods
        void Insert(T entity);
        void Remove(IEnumerable<T> entities);
        void Remove(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entityToUpdate);
        void Update(IEnumerable<T> entityToUpdate);
        Task<bool> CheckExist(Expression<Func<T, bool>> predicate, Ref<CheckError> checkError = null);
        Task<int> GetCount(Expression<Func<T, bool>> predicate, Ref<CheckError> checkError = null);
        Task<T> GetById(object id, Ref<CheckError> checkError = null);
        Task<IEnumerable<T>> Get(string storedProcedureName, SqlParameter[] parameters , Ref<CheckError> checkError = null);
        Task<T> GetOne(string storedProcedureName, SqlParameter[] parameters = null, Ref<CheckError> checkError = null);
        IEnumerable<SqlParameter> GetOutPut(string storedProcedureName, SqlParameter[] parameters, Ref<CheckError> checkError = null);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> Delete(object id, Ref<CheckError> checkError = null);
        Task<bool> Delete(T entity, Ref<CheckError> checkError = null);
        Task<bool> DeleteAll(IList<T> list, Ref<CheckError> checkError = null);
        IQueryable<T> GetQueryable();

    #endregion
    }
}
