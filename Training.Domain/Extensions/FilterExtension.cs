using System.Linq.Expressions;
using System.Reflection;
using Training.Domain.Command.Users;


namespace Training.Domain.Extensions
{
    public static class FilterExtension
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> input, List<SearchObjForCondition> filter)
        {
            foreach (var item in filter)
            {
                PropertyInfo getter = typeof(T).GetProperty(item.Field);
                var param = Expression.Parameter(typeof(T));
                if (getter != null)
                {
                    var body = Expression.Equal(
                        Expression.Property(param, getter.Name),
                        Expression.Constant(item.Value));

                    MethodCallExpression result = Expression.Call(
                        typeof(Queryable),
                        "Where",
                        new[] { typeof(T) },
                        input.Expression,
                        Expression.Lambda<Func<T, bool>>(body, param));


                    input = input.Provider.CreateQuery<T>(result);
                }
            }
            return input;
        }
    }
}
