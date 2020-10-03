namespace GuessTheNumber.SignalR.EventHandlers
{
    using System.Threading.Tasks;
    using Confluent.Kafka;
    using GuessTheNumber.Kafka.Interfaces;
    using GuessTheNumber.SignalR.Events;
    using GuessTheNumber.SignalR.Hubs;
    using GuessTheNumber.SignalR.Interfaces;
    using Microsoft.AspNetCore.SignalR;
    using Newtonsoft.Json;

    public class GameWonHandler : IEventHandler<Ignore, GameEvent>
    {
        public int EventType { get; private set; } = 1;

        private readonly IHubContext<GameHub, IGameClient> commentHubContext;

        public GameWonHandler(IHubContext<GameHub, IGameClient> commentHubContext)
        {
            this.commentHubContext = commentHubContext;
        }

        public async Task HandleAsync(Ignore key, GameEvent @event)
        {
            var value = (GameWon)JsonConvert.DeserializeObject(@event.Value);
            await this.commentHubContext.Clients.All.SendGameWonMessage(value.WinnerUsername);
        }
    }
}