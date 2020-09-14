namespace GuessTheNumber.BLL.Converters
{
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.DAL.Entities;

    public static partial class Converters
    {
        public static GameInfoContract ToContract(this Game game)
        {
            return new GameInfoContract
            {
                Id = game.Id,
                Length = game.EndTime.Value.Subtract(game.StartTime),
                Number = game.Number,
                ParticipatsIds = game.Attempts.Select(a => a.UserId).Distinct().ToArray(),
                WinnerId = game.WinnerId,
                OwnerId = game.OwnerId
            };
        }
    }
}