namespace GuessTheNumber.SignalR
{
    using Confluent.Kafka;
    using GuessTheNumber.Kafka.Extensions;
    using GuessTheNumber.SignalR.EventHandlers;
    using GuessTheNumber.SignalR.Events;
    using GuessTheNumber.SignalR.Hubs;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSignalR();

            services.AddKafkaConsumer<Ignore, GameWon, GameWonHandler>(p =>
            {
                p.Topic = "game_events";
                p.GroupId = "game_group";
                p.BootstrapServers = "localhost:9092";
            });

            services.AddKafkaConsumer<Ignore, GameOver, GameOverHandler>(p =>
            {
                p.Topic = "game_events";
                p.GroupId = "game_group";
                p.BootstrapServers = "localhost:9092";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<GameHub>("/gamehub");
            });

        }
    }
}