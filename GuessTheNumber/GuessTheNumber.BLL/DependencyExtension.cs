namespace GuessTheNumber.BLL
{
    using GuessTheNumber.Core;
    using GuessTheNumber.Core.Entities;
    using GuessTheNumber.DAL;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyExtension
    {
        public static IServiceCollection AddRepository<TEntity, TContext>(this IServiceCollection services)
            where TEntity : BaseEntity
            where TContext : DbContext
        {
            return services.AddScoped(typeof(IRepository<TEntity>), typeof(Repository<TEntity, TContext>));
        }
    }
}