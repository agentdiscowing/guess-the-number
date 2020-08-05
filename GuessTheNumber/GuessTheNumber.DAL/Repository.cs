namespace GuessTheNumber.DAL
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using GuessTheNumber.Core;
    using GuessTheNumber.DAL.Entities;
    using Microsoft.EntityFrameworkCore;

    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly DbContext context;

        private readonly DbSet<T> set;

        public Repository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.set.Where(predicate);
        }

        public T Insert(T entity)
        {
            return this.set.Add(entity).Entity;
        }

        public async Task SaveChangesAsync()
        {
           await this.context.SaveChangesAsync();
        }
    }
}