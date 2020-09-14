namespace GuessTheNumber.Web.Extensions.ConvertingExtensions
{
    using System.Collections.Generic;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.Web.Models.Response;

    public static partial class ConvertingExtensions
    {
        public static IEnumerable<GameInfoResponse> ToResponseList(this IEnumerable<GameInfoContract> gameInfoList, string userId)
        {
            return gameInfoList.Select(gi => gi.ToResponse(userId));
        }
    }
}