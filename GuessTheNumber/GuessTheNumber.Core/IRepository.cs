namespace GuessTheNumber.Core
{
    using System.Threading.Tasks;

    public interface IRepository<T>
        where T : class
    {
        T Insert(T entity);

        Task SaveChangesAsync();
    }
}