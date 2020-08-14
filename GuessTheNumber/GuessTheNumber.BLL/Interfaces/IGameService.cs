﻿namespace GuessTheNumber.BLL.Interfaces
{
    using System.Collections.Generic;
    using GuessTheNumber.BLL.Contracts;
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

    public interface IGameService
    {
        // return the number of the game, stops the active game if there is one
        int StartGame(string userId, int number, int? currentGameId);

        // return one of possible results, owner of the game cannot make an attempt
        GuessResultContract MakeGuess(string userId, int number, int? currentGameId);

        // checks is user has active game and ends it
        void LeaveGame(string userId, int? currentGameId);

        // return current game state
        GameStates GetGameState(int? currentGameId);

        // return a page of won games
        IList<GameInfoContract> GetGameHistory(int page, int gamesPerPage, string userId);
    }
}