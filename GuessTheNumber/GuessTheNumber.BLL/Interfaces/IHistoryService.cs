namespace GuessTheNumber.BLL.Interfaces
{
    using System.Collections.Generic;
    using GuessTheNumber.BLL.Contracts;

    public interface IHistoryService
    {
        // return a page of won games
        IList<GameInfoContract> GetGameHistory(int page, int gamesPerPage);
    }
}