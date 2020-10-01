namespace GuessTheNumber.Kafka.Producer
{
    using Confluent.Kafka;
    using GuessTheNumber.Kafka.Interfaces;
    using Microsoft.Extensions.Options;

    public class KafkaProducer : IProducer
    {
        private readonly KafkaProducerConfig config;

        public KafkaProducer(IOptions<KafkaProducerConfig> config)
        {
            this.config = config.Value;
        }

        public void Produce<TKey, TValue>(string topic, TKey key, TValue val, ISerializer<TValue> serializer)
        {
            using (var producer = new ProducerBuilder<TKey, TValue>(this.config).SetValueSerializer(serializer).Build())
            {
                producer.ProduceAsync(topic, new Message<TKey, TValue> { Value = val, Key = key }).Wait();
            }
        }
    }
}