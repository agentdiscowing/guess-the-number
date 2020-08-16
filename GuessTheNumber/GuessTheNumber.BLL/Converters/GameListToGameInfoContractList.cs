namespace GuessTheNumber.BLL.Converters
{
    using System.Collections.Generic;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.DAL.Entities;

    public static partial class Converters
    {
        public static IList<GameInfoContract> ToContractList(this IEnumerable<Game> games)
        {
            return games.Select(g => g.ToContract()).ToList();
        }

    }
}