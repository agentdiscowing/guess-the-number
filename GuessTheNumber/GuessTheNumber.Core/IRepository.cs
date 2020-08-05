namespace GuessTheNumber.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<T>
        where T : class
    {
        T Insert(T entity);

        Task SaveChangesAsync();

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}