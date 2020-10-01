namespace GuessTheNumber.SignalR.EventHandlers
{
    using System.Threading.Tasks;
    using Confluent.Kafka;
    using GuessTheNumber.Kafka.Interfaces;
    using GuessTheNumber.SignalR.Events;
    using GuessTheNumber.SignalR.Hubs;
    using GuessTheNumber.SignalR.Interfaces;
    using Microsoft.AspNetCore.SignalR;

    public class GameWonHandler : IEventHandler<Ignore, GameWon>
    {
        private readonly IHubContext<GameHub, IGameClient> commentHubContext;

        public GameWonHandler(IHubContext<GameHub, IGameClient> commentHubContext)
        {
            this.commentHubContext = commentHubContext;
        }

        public async Task HandleAsync(Ignore key, GameWon @event)
        {
            await this.commentHubContext.Clients.All.SendGameWonMessage(@event.WinnerUsername);
        }
    }
}