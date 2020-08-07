namespace GuessTheNumber.DAL
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using GuessTheNumber.Core;
    using GuessTheNumber.Core.Entities;
    using Microsoft.EntityFrameworkCore;

    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext context;

        private readonly DbSet<TEntity> set;

        public Repository(TContext context)
        {
            this.context = context;
            this.set = this.context.Set<TEntity>();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.set.Where(predicate);
        }

        public TEntity Insert(TEntity entity)
        {
            return this.set.Add(entity).Entity;
        }

        public async Task SaveChangesAsync()
        {
           await this.context.SaveChangesAsync();
        }
    }
}