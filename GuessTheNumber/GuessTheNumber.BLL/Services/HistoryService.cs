namespace GuessTheNumber.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
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

        public IList<GameInfoContract> GetGameHistory(int page, int gamesPerPage)
        {
            var wonGames = this.gameRepository.Find(g => g.WinnerId != null).Skip(--page * gamesPerPage).Take(gamesPerPage).OrderBy(g => g.StartTime);

            return wonGames.Select(g => new GameInfoContract
            {
                Length = g.EndTime.Value.Subtract(g.StartTime),
                Number = g.Number,
                ParticipatsIds = g.Attempts.Select(a => a.UserId).ToArray(),
                WinnerId = g.WinnerId
            }).ToList();
        }
    }
}