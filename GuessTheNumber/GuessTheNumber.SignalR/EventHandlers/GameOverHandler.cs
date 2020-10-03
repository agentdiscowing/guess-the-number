namespace GuessTheNumber.SignalR.EventHandlers
{
    using System.Threading.Tasks;
    using Confluent.Kafka;
    using GuessTheNumber.Kafka.Interfaces;
    using GuessTheNumber.SignalR.Hubs;
    using GuessTheNumber.SignalR.Interfaces;
    using Microsoft.AspNetCore.SignalR;

    public class GameOverHandler : IEventHandler<Ignore, GameEvent>
    {
        private readonly IHubContext<GameHub, IGameClient> commentHubContext;

        public GameOverHandler(IHubContext<GameHub, IGameClient> commentHubContext)
        {
            this.commentHubContext = commentHubContext;
        }

        public int EventType { get; private set; } = 2;

        public async Task HandleAsync(Ignore key, GameEvent @event)
        {
            await this.commentHubContext.Clients.All.SendGameOverMessage();
        }
    }
}