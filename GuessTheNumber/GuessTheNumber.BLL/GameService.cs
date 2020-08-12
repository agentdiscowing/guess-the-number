namespace GuessTheNumber.BLL
{
    using System;
    using System.Linq;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Core;
    using GuessTheNumber.Core.Entities;
    using GuessTheNumber.Core.Exceptions;

    public class GameService : IGameService
    {
        private readonly IRepository<Game> gameRepository;

        public GameService(IRepository<Game> gameRepo)
        {
            this.gameRepository = gameRepo;
        }

        public bool GameIsStarted()
        {
            return this.GetActiveGame() != null;
        }

        public GameAttemptResults MakeAttempt(int userId, int number)
        {
            var currGame = this.GetActiveGame();

            if (currGame == null)
            {
                throw new GuessTheNumberNoActiveGameException();
            }

            if (userId == currGame.OwnerId)
            {
                throw new GuessTheNumberOwnerAttemptException();
            }

            currGame.Attempts.Add(new Attempt
            {
                GameId = currGame.Id,
                Number = number,
                UserId = userId,
            });

            this.gameRepository.SaveChangesAsync();

            switch (number.CompareTo(currGame.Number))
            {
                case 0:
                    this.EndGame(userId);
                    return GameAttemptResults.WIN;
                case 1:
                    return GameAttemptResults.MORE;
                default:
                    return GameAttemptResults.LESS;
            }
        }

        public int StartGame(int userId, int number)
        {
            if (this.GameIsStarted())
            {
                this.EndGame();
            }

            var newGame = this.gameRepository.Insert(new Game
            {
                Number = number,
                EndTime = null,
                StartTime = DateTime.Now,
                OwnerId = userId,
                WinnerId = null
            });

            this.gameRepository.SaveChangesAsync();

            return newGame.Number;
        }

        public void EndGame(int? winnerId = null)
        {
            var currGame = this.GetActiveGame();

            if (currGame == null)
            {
                throw new GuessTheNumberNoActiveGameException();
            }

            currGame.EndTime = DateTime.Now;

            currGame.WinnerId = winnerId;

            this.gameRepository.SaveChangesAsync();
        }

        private Game GetActiveGame()
        {
            return this.gameRepository.Find(g => g.EndTime == null).FirstOrDefault();
        }
    }
}