namespace GuessTheNumber.Web
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.BLL.Services;
    using GuessTheNumber.DAL;
    using GuessTheNumber.DAL.Entities;
    using GuessTheNumber.Web.Extensions.ServicesExtensions;
    using GuessTheNumber.Web.Filters;
    using GuessTheNumber.Web.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSession();

            services.AddSwagger();

            services.AddJwtTokens(this.Configuration);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add<ExceptionFilter>();
                    options.Filters.Add<ValidationFilter>();
                }) // to supress "possible object cycle" filter
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            var connectionString = this.Configuration.GetValue<string>("ConnectionString");

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client/dist/guess-the-number";
            });

            services.AddDbContext<GameContext>(options => options.UseSqlServer(connectionString)
                                                                 .UseLazyLoadingProxies());

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                   .AddRoles<IdentityRole>()
                   .AddEntityFrameworkStores<GameContext>();

            services.AddScoped(typeof(IAuthService), typeof(AuthService));
            services.AddScoped(typeof(IRepository<Game>), typeof(Repository<Game, GameContext>));
            services.AddScoped(typeof(IGameService), typeof(GameService));
            services.AddScoped(typeof(IHistoryService), typeof(HistoryService));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            try
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseSession();

                app.UseAuthentication();

                app.UseAuthorization();

                // to workaround CORS policy
                app.Use(async (r, next) =>
                {
                    if (r.Request.Headers.Keys.Contains("Origin", StringComparer.OrdinalIgnoreCase) &&
                        r.Request.Method == "OPTIONS")
                    {
                        r.Response.OnStarting(() =>
                        {
                            r.Response.StatusCode = 200;
                            r.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type, Authorization";
                            return Task.CompletedTask;
                        });
                    }
                    await next();
                });

                app.UseStaticFiles();
                if (!env.IsDevelopment())
                {
                    app.UseSpaStaticFiles();
                }

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                app.UseSpa(spa =>
                {
                    // To learn more about options for serving an Angular SPA from ASP.NET Core,
                    // see https://go.microsoft.com/fwlink/?linkid=864501

                    spa.Options.SourcePath = "client";

                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start");
                    }
                });

                app.UseSwagger();

                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api"));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}