namespace GuessTheNumber.Web.Events
{
    using GuessTheNumber.Kafka.Interfaces;

    public class GameWon : IEvent
    {
        public string WinnerUsername { get; set; }
    }
}