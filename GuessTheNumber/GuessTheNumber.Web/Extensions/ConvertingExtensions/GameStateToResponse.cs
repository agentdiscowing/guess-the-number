namespace GuessTheNumber.Web.Extensions.ConvertingExtensions
{
    using GuessTheNumber.Core.Resources;
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

    public static partial class ConvertingExtensions
    {
        public static string ToResponse(this GameStates gameState)
        {
            string message = gameState switch
            {
                GameStates.ACTIVE => GameMessages.GameIsActive,
                GameStates.WON => GameMessages.GameIsWon,
                GameStates.OVER => GameMessages.GameIsOver
            };
            return message;
        }
    }
}