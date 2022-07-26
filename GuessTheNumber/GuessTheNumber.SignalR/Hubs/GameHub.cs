﻿namespace GuessTheNumber.SignalR.Hubs
{
    using System.Threading.Tasks;
    using GuessTheNumber.SignalR.Interfaces;
    using Microsoft.AspNetCore.SignalR;

    public class GameHub : Hub<IGameClient>
    {
        public Task NotifyGameStarted(string ownerUsername)
        {
            return this.Clients.Others.SendGameStartedMessage($"{ownerUsername} started a new game");
        }
    }
}