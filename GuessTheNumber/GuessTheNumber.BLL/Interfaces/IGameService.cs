namespace GuessTheNumber.BLL.Interfaces
{
    using GuessTheNumber.BLL.Contracts;

    public interface IGameService
    {
        int? StartGame(int userId, int number);

        GameAttemptResults MakeAttempt(int userId, int number);

        ShortGameInfoContract GetActiveGame();

        bool ForceEndGame(int userId);
    }
}