using GuessTheNumber.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumber.BLL.Interfaces
{
    public interface IGameService
    {
        // if game is already started return null, else return the number of the game
        int? StartGame(int userId, int number);

        // if user is not entitled to end the game return false, else true (manually or on log off)
        // if the game was forced to end then there is no winner
        bool EndGame(int userId, int? winnerId = null);

        // return -1 if number if less than was set, 0 if it is right, 1 if it's more than was set
        int MakeAttempt(int userId, int number);

        // check if there is a game going on rn
        ShortGameInfoContract GetActiveGame();
    }
}