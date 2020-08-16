namespace GuessTheNumber.BLL.Converters
{
    using System.Collections.Generic;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.DAL.Entities;

    public static partial class Converters
    {
        public static IList<GuessContract> ToContractList(this IEnumerable<Guess> guesses)
        {
            return guesses.Select(g => g.ToContract()).ToList();
        }
    }
}