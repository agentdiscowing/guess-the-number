namespace GuessTheNumber.Kafka.Producer
{
    using Confluent.Kafka;

    public class KafkaProducer
    {
        private readonly ProducerConfig config;

        public KafkaProducer(ProducerConfig config)
        {
            this.config = config;
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