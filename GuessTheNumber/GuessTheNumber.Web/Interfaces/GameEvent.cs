namespace GuessTheNumber.Web.Interfaces
{
    using GuessTheNumber.Kafka.Interfaces;

    public class GameEvent : IEvent
    {
        public int EventType { get; set; }

        public string Value { get; set; }
    }
}