namespace GuessTheNumber.BLL.Services
{
    using System;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.DAL;
    using GuessTheNumber.DAL.Entities;
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

        public GuessResultContract MakeGuess(string userId, int number)
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

            currGame.Attempts.Add(new Guess
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

            return new GuessResultContract
            {
                Number = number,
                Result = (GameAttemptResults)number.CompareTo(currGame.Number)
            };
        }

        public int StartGame(string userId, int number)
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

        public void EndGame(string winnerId = null)
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

        public void LeaveGame(string userId)
        {
            if (this.GetActiveGame().OwnerId == userId)
            {
                this.EndGame();
            }
        }
    }
}