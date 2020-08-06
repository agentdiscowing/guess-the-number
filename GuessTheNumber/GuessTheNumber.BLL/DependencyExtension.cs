namespace GuessTheNumber.BLL
{
    using GuessTheNumber.Core;
    using GuessTheNumber.Core.Entities;
    using GuessTheNumber.DAL;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyExtension
    {
        public static IServiceCollection AddRepository<T>(this IServiceCollection services)
            where T : BaseEntity
        {
            return services.AddScoped(typeof(IRepository<T>), typeof(Repository<T>));
        }
    }
}