namespace GuessTheNumber.Web.Extensions.ConvertingExtensions
{
    using GuessTheNumber.Core.Resources;
    using GuessTheNumber.Web.Models.Response;
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

    public static partial class ConvertingExtensions
    {
        public static GameStateResponse ToResponse(this GameStates gameState)
        {
            GameStateResponse response = gameState switch
            {
                GameStates.ACTIVE => new GameStateResponse(GameMessages.GameIsActive, "active"),
                GameStates.WON => new GameStateResponse(GameMessages.GameIsWon, "won"),
                GameStates.OVER => new GameStateResponse(GameMessages.GameIsOver, "over")
            };

            return response;
        }
    }
}