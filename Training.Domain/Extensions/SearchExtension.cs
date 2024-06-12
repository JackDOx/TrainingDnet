using System.Linq.Expressions;
using System.Reflection;
using Training.Domain.Command.Users;
using Training.Entity.EntityModel;


namespace Training.Domain.Extensions
{
    public static class SearcExtension
    {
        public static IQueryable<T> Search<T>(this IQueryable<T> input, List<SearchObjForCondition> search)
        {

            foreach (var item in search)
            {
                PropertyInfo getter = typeof(T).GetProperty(item.Field);

                if (getter != null)
                {
                    var param = Expression.Parameter(typeof(T), "item");

                    var propertyValue = Expression.Property(param, getter);
                    var searchValue = Expression.Constant(item.Value);

                    // Create a case-insensitive comparison
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var comparison = Expression.Call(propertyValue, containsMethod, searchValue);

                    var lambda = Expression.Lambda<Func<T, bool>>(comparison, param);
                    input = input.Where(lambda);
                }
            }
            return input;
        }
    }
}
