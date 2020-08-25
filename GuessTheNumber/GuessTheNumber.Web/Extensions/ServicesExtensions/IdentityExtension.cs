namespace GuessTheNumber.Web.Extensions.ServicesExtensions
{
    using GuessTheNumber.Web.Services;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ServiceExtensions
    {
        public static IServiceCollection AddIdentity<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                   .AddRoles<IdentityRole>()
                   .AddEntityFrameworkStores<TContext>();

            services.AddScoped(typeof(IAuthService), typeof(AuthService));

            return services;
        }
    }
}