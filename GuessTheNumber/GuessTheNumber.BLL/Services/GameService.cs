namespace GuessTheNumber.BLL.Services
{
    using System;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Core;
    using GuessTheNumber.Core.Entities;
    using GuessTheNumber.Core.Exceptions;
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

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

        public AttemptResultContract MakeAttempt(int userId, int number)
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

            this.gameRepository.SaveChangesAsync().Wait();

            if (currGame.Number == number)
            {
                this.EndGame(userId);
            }

            return new AttemptResultContract
            {
                Number = number,
                Result = (GameAttemptResults)number.CompareTo(currGame.Number)
            };
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

            this.gameRepository.SaveChangesAsync().Wait();

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

            this.gameRepository.SaveChangesAsync().Wait();
        }

        public void LeaveGame(int userId)
        {
            if (this.GetActiveGame().OwnerId == userId)
            {
                this.EndGame();
            }
        }

        private Game GetActiveGame()
        {
            return this.gameRepository.Find(g => g.EndTime == null).FirstOrDefault();
        }
    }
}