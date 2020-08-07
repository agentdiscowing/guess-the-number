using GuessTheNumber.BLL.Contracts;
using GuessTheNumber.BLL.Interfaces;
using GuessTheNumber.Core;
using GuessTheNumber.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessTheNumber.BLL
{
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

        public bool EndGame(int userId, int? winnerId = null)
        {
            throw new NotImplementedException();
        }

        public int MakeAttempt(int userId, int number)
        {
            throw new NotImplementedException();
        }

        public int? StartGame(int userId, int number)
        {
            throw new NotImplementedException();
        }
    }
}
