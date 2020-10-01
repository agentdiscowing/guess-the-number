namespace GuessTheNumber.Kafka.Extensions
{
    using System;
    using GuessTheNumber.Kafka.Consumer;
    using GuessTheNumber.Kafka.Interfaces;
    using GuessTheNumber.Kafka.Producer;
    using Microsoft.Extensions.DependencyInjection;

    public static class RegisterServiceExtensions
    {
        public static IServiceCollection AddKafkaConsumer<TKey, TValue, THandler>(this IServiceCollection services, Action<KafkaConsumerConfig> configAction)
            where THandler : class, IEventHandler<TKey, TValue>
            where TValue : IEvent
        {
            services.AddScoped<IEventHandler<TKey, TValue>, THandler>();

            services.AddHostedService<KafkaConsumer<TKey, TValue>>();

            services.Configure(configAction);

            return services;
        }

        public static IServiceCollection AddKafkaProducer(this IServiceCollection services, Action<KafkaProducerConfig> configAction)
        {
            services.AddSingleton(typeof(IProducer), typeof(KafkaProducer));

            services.Configure(configAction);

            return services;
        }
    }
}