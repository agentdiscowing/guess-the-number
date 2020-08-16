using GuessTheNumber.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumber.BLL.Interfaces
{
    public interface IHistoryService
    {
        // return a page of won games
        IList<GameInfoContract> GetGameHistory(int page, int gamesPerPage, string userId);
    }
}