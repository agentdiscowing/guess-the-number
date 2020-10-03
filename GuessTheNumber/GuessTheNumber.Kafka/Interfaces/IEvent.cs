namespace GuessTheNumber.Kafka.Interfaces
{
    public interface IEvent
    {
        int EventType { get; }
    }
}