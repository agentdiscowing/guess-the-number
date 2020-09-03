namespace GuessTheNumber.Web.Hubs
{
    using System.Threading.Tasks;
    using GuessTheNumber.Web.Interfaces;
    using Microsoft.AspNetCore.SignalR;

    public class GameHub : Hub<IGameClient>
    {
        public Task NotifyGameStarted(string ownerUsername)
        {
            return this.Clients.Others.SendGameStartedMessage($"{ownerUsername} started a new game");
        }

        public Task NotifyGameWon(string winnerUsername)
        {
            return this.Clients.Others.SendGameWonMessage($"{winnerUsername} won the game");
        }

        public Task NotifyGameOver()
        {
            return this.Clients.Others.SendGameOverMessage($"Game is interrupted");
        }
    }
}