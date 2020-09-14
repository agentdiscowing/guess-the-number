namespace GuessTheNumber.Web.Extensions.ConvertingExtensions
{
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.Web.Models.Response;

    public static partial class ConvertingExtensions
    {
        public static GameInfoResponse ToResponse(this GameInfoContract gameInfo, string userId)
        {
            return new GameInfoResponse
            {
                Id = gameInfo.Id,
                Length = gameInfo.Length.ToString(@"hh\:mm\:ss"),
                Number = gameInfo.Number,
                IsOwner = gameInfo.OwnerId == userId,
                IsParticipant = gameInfo.ParticipatsIds.Contains(userId),
                IsWinner = gameInfo.WinnerId == userId
            };
        }
    }
}