namespace GuessTheNumber.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.BLL.Converters;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.DAL;
    using GuessTheNumber.DAL.Entities;

    public class HistoryService : IHistoryService
    {
        private readonly IRepository<Game> gameRepository;

        public HistoryService(IRepository<Game> gameRepo)
        {
            this.gameRepository = gameRepo;
        }

        public IList<GuessContract> GetGameGuesses(int gameId)
        {
            var game = this.gameRepository.Find(g => g.Id == gameId).Single();

            return game.Attempts.ToContractList();
        }

        public IList<GameInfoContract> GetGameHistory(int page, int gamesPerPage)
        {
            var wonGames = this.gameRepository.Find(g => g.WinnerId != null)
                                              .Skip(--page * gamesPerPage)
                                              .Take(gamesPerPage)
                                              .OrderBy(g => g.StartTime)
                                              .ToList();

            return wonGames.ToContractList();
        }
    }
}