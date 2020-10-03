namespace GuessTheNumber.SignalR.Interfaces
{
    using GuessTheNumber.Kafka.Interfaces;

    public class GameEvent : IEvent
    {
        public int EventType { get; }

        public string Value { get; }
    }
}