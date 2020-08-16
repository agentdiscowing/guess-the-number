namespace GuessTheNumber.BLL.Interfaces
{
    using System.Collections.Generic;
    using GuessTheNumber.BLL.Contracts;

    public interface IHistoryService
    {
        // return a page of won games
        IList<GameInfoContract> GetGameHistory(int page, int gamesPerPage);

        // return a list of guesses of the game
        IList<GuessContract> GetGameGuesses(int gameId);
    }
}