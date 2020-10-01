namespace GuessTheNumber.Kafka.Producer
{
    using Confluent.Kafka;

    public class KafkaProducerConfig : ProducerConfig
    {
        public string Topic { get; set; }
    }
}