namespace GuessTheNumber.BLL.Interfaces
{
    using GuessTheNumber.BLL.Contracts;

    public interface IGameService
    {
        // return the number of the game, stops the active game if there is one
        int StartGame(int userId, int number);

        // return one of possible results, owner of the game cannot make an attempt
        AttemptResultContract MakeAttempt(int userId, int number);

        // checks if there is an active game
        bool GameIsStarted();

        // ends game, if game is force-ended null is passed as winner id
        void EndGame(int? winnerId);
    }
}