namespace GuessTheNumber.Web
{
    using System;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.BLL.Services;
    using GuessTheNumber.DAL;
    using GuessTheNumber.DAL.Entities;
    using GuessTheNumber.Web.Extensions.ServicesExtensions;
    using GuessTheNumber.Web.Filters;
    using GuessTheNumber.Web.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
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

            services.AddIdentity<GameContext>();

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