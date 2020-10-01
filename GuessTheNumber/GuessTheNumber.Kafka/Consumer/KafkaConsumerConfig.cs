namespace GuessTheNumber.Kafka.Consumer
{
    using Confluent.Kafka;

    public class KafkaConsumerConfig : ConsumerConfig
    {
        public KafkaConsumerConfig()
        {
            this.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
            this.EnableAutoOffsetStore = false;
        }

        public string Topic { get; set; }
    }
}