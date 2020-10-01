using GuessTheNumber.Kafka.Interfaces;

namespace GuessTheNumber.SignalR.Events
{
    public class GameWon: IEvent
    {
        public string WinnerUsername { get; set; }
    }
}
