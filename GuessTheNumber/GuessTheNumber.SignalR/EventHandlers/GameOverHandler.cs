namespace GuessTheNumber.SignalR.EventHandlers
{
    using System.Threading.Tasks;
    using Confluent.Kafka;
    using GuessTheNumber.Kafka.Interfaces;
    using GuessTheNumber.SignalR.Events;
    using GuessTheNumber.SignalR.Hubs;
    using GuessTheNumber.SignalR.Interfaces;
    using Microsoft.AspNetCore.SignalR;

    public class GameOverHandler: IEventHandler<Ignore, GameOver>
    {
        private readonly IHubContext<GameHub, IGameClient> commentHubContext;

        public GameOverHandler(IHubContext<GameHub, IGameClient> commentHubContext)
        {
            this.commentHubContext = commentHubContext;
        }

        public async Task HandleAsync(Ignore key, GameOver @event)
        {
            await this.commentHubContext.Clients.All.SendGameOverMessage();
        }
    }
}