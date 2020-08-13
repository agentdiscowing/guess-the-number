namespace GuessTheNumber.BLL.Interfaces
{
    using GuessTheNumber.BLL.Contracts;

    public interface IGameService
    {
        // return the number of the game, stops the active game if there is one
        int StartGame(string userId, int number, int? currentGameId);

        // return one of possible results, owner of the game cannot make an attempt
        GuessResultContract MakeGuess(string userId, int number, int? currentGameId);

        // checks is user has active game and ends it
        void LeaveGame(string userId, int? currentGameId);

    }
}