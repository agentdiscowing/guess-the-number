namespace GuessTheNumber.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Core.Exceptions;
    using GuessTheNumber.DAL;
    using GuessTheNumber.DAL.Entities;
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

    public class GameService : IGameService
    {
        private readonly IRepository<Game> gameRepository;

        public GameService(IRepository<Game> gameRepo)
        {
            this.gameRepository = gameRepo;
        }

        public GuessResultContract MakeGuess(string userId, int number, int? currentGameId)
        {
            if (currentGameId == null)
            {
                throw new GuessTheNumberNoActiveGameException();
            }

            var currentGame = this.gameRepository.Find(g => g.Id == currentGameId).Single();

            if (currentGame.EndTime != null)
            {
                throw new GuessTheNumberGameOverException();
            }

            if (userId == currentGame.OwnerId)
            {
                throw new GuessTheNumberOwnerAttemptException();
            }

            currentGame.Attempts.Add(new Guess
            {
                GameId = currentGame.Id,
                Number = number,
                UserId = userId,
            });

            this.gameRepository.SaveChangesAsync().Wait();

            if (currentGame.Number == number)
            {
                this.EndGame(userId, currentGameId.Value);
            }

            return new GuessResultContract
            {
                Number = number,
                Result = (GameAttemptResults)number.CompareTo(currentGame.Number)
            };
        }

        public int StartGame(string userId, int number, int? currentGameId)
        {
            if (currentGameId != null)
            {
                this.ForceEndGame(currentGameId.Value);
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

            return newGame.Id;
        }

        public void LeaveGame(string userId, int? currentGameId)
        {
            if (currentGameId == null)
            {
                return;
            }

            var currentGame = this.gameRepository.Find(g => g.Id == currentGameId).Single();

            if (currentGame.OwnerId == userId)
            {
                this.ForceEndGame(currentGameId.Value);
            }
        }

        public GameStates GetGameState(int? currentGameId)
        {
            if (currentGameId == null)
            {
                throw new GuessTheNumberNoActiveGameException();
            }

            var currentGame = this.gameRepository.Find(g => g.Id == currentGameId).Single();

            GameStates state = currentGame.EndTime switch
            {
                null => GameStates.ACTIVE,
                _ => currentGame.WinnerId == null ? GameStates.OVER : GameStates.WON
            };

            return state;
        }

        private void EndGame(string winnerId, int currentGameId)
        {
            var currentGameEntity = this.gameRepository.Find(g => g.Id == currentGameId).Single();

            currentGameEntity.EndTime = DateTime.Now;

            currentGameEntity.WinnerId = winnerId;

            this.gameRepository.SaveChangesAsync().Wait();
        }

        private void ForceEndGame(int currentGameId)
        {
            var currentGameEntity = this.gameRepository.Find(g => g.Id == currentGameId).Single();

            currentGameEntity.EndTime = DateTime.Now;

            this.gameRepository.SaveChangesAsync().Wait();
        }

        public IList<GameInfoContract> GetGameHistory(int page, int gamesPerPage, string userId)
        {
            var wonGames = this.gameRepository.Find(g => g.WinnerId != null).Skip(--page * gamesPerPage).Take(gamesPerPage).OrderBy(g => g.StartTime);

            return wonGames.Select(g => new GameInfoContract
            {
                Length = g.EndTime.Value.Subtract(g.StartTime),
                Number = g.Number,
                ParticipatedByUser = g.Attempts.Any(a => a.UserId == userId),
                WonByUser = g.WinnerId == userId
            }).ToList();
        }
    }
}