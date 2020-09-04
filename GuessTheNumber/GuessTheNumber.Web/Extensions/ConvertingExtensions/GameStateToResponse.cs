namespace GuessTheNumber.Web.Extensions.ConvertingExtensions
{
    using GuessTheNumber.Core.Resources;
    using GuessTheNumber.Web.Models.Response;
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

    public static partial class ConvertingExtensions
    {
        public static GameStateResponse ToResponse(this GameStates gameState, bool isOwner)
        {
            GameStateResponse response = gameState switch
            {
                GameStates.ACTIVE => new GameStateResponse(GameMessages.GameIsActive, "active", isOwner),
                GameStates.WON => new GameStateResponse(GameMessages.GameIsWon, "won", isOwner),
                GameStates.OVER => new GameStateResponse(GameMessages.GameIsOver, "over", isOwner)
            };

            return response;
        }
    }
}