namespace GuessTheNumber.BLL
{
    using System;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Core;
    using GuessTheNumber.Core.Entities;

    public class GameService : IGameService
    {
        private readonly IRepository<Game> gameRepository;

        public GameService(IRepository<Game> gameRepo)
        {
            this.gameRepository = gameRepo;
        }

        public ShortGameInfoContract GetActiveGame()
        {
            var activeGame = this.gameRepository.Find(g => g.EndTime == null).FirstOrDefault();

            if (activeGame == null)
            {
                return null;
            }

            return new ShortGameInfoContract
            {
                Id = activeGame.Id,
                OwnerUsername = activeGame.Owner.Username
            };
        }

        public GameAttemptResults MakeAttempt(int userId, int number)
        {
            var currGame = this.GetActiveFullGame();

            if (userId == currGame.OwnerId)
            {
                return GameAttemptResults.OWN;
            }

            currGame.Attempts.Add(new Attempt
            {
                GameId = currGame.Id,
                Number = number,
                UserId = userId,
            });

            this.gameRepository.SaveChangesAsync();

            if (number == currGame.Number)
            {
                this.EndGame(userId);

                return GameAttemptResults.WIN;
            }

            return number < currGame.Number ? GameAttemptResults.LESS : GameAttemptResults.MORE;
        }

        public int? StartGame(int userId, int number)
        {
            var activeGameCheck = this.GetActiveFullGame();

            if (activeGameCheck != null)
            {
                return null;
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

        public bool ForceEndGame(int userId)
        {
            throw new NotImplementedException();
        }

        private Game GetActiveFullGame()
        {
            return this.gameRepository.Find(g => g.EndTime == null).FirstOrDefault();
        }

        private void EndGame(int winnerId)
        {
            var currGame = this.GetActiveFullGame();

            currGame.EndTime = DateTime.Now;

            currGame.WinnerId = winnerId;

            this.gameRepository.SaveChangesAsync();
        }
    }
}