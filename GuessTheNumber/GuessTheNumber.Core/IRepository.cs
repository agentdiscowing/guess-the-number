using System;
using System.Threading.Tasks;

namespace GuessTheNumber.Core
{
    public interface IRepository<T> where T: class
    {
        T Insert(T entity);

        Task SaveChangesAsync();
    }
}
