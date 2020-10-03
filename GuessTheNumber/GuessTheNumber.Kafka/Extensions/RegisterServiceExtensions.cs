namespace GuessTheNumber.Kafka.Extensions
{
    using System;
    using System.Collections.Generic;
    using GuessTheNumber.Kafka.Consumer;
    using GuessTheNumber.Kafka.Interfaces;
    using GuessTheNumber.Kafka.Producer;
    using Microsoft.Extensions.DependencyInjection;

    public static class RegisterServiceExtensions
    {
        public static IServiceCollection AddKafkaConsumer<TKey, TValue>(this IServiceCollection services, IEnumerable<Type> handlersTypes, Action<KafkaConsumerConfig> configAction)
            where TValue : IEvent
        {
            foreach (var handlerType in handlersTypes)
            {
                services.AddScoped(typeof(IEventHandler<TKey, TValue>), handlerType);
            }

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