namespace GuessTheNumber.Kafka.Consumer
{
    using System.Threading;
    using System.Threading.Tasks;
    using Confluent.Kafka;
    using GuessTheNumber.Kafka.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;

    public class KafkaConsumer<TKey, TValue> : BackgroundService
        where TValue : IEvent
    {
        private readonly KafkaConsumerConfig config;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private IEventHandler<TKey, TValue> handler;

        public KafkaConsumer(IOptions<KafkaConsumerConfig> config, IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.config = config.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                this.handler = scope.ServiceProvider.GetRequiredService<IEventHandler<TKey, TValue>>();

                var builder = new ConsumerBuilder<TKey, TValue>(this.config).SetValueDeserializer(new KafkaSerializer<TValue>());

                using (IConsumer<TKey, TValue> consumer = builder.Build())
                {
                    consumer.Subscribe(this.config.Topic);

                    while (!stoppingToken.IsCancellationRequested)
                    {
                        var result = consumer.Consume();

                        if (result != null)
                        {
                            await this.handler.HandleAsync(result.Message.Key, result.Message.Value);

                            consumer.Commit(result);

                            consumer.StoreOffset(result);
                        }
                    }
                }
            }
        }
    }
}