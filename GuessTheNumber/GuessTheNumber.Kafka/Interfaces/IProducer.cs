namespace GuessTheNumber.Kafka.Interfaces
{
    using Confluent.Kafka;

    public interface IProducer
    {
        void Produce<TKey, TValue>(string topic, TKey key, TValue val, ISerializer<TValue> serializer)
            where TValue : IEvent;
    }
}