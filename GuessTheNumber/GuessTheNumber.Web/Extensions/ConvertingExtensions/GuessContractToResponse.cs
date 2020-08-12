namespace GuessTheNumber.Web.Extensions.ConvertingExtensions
{
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.Core.Constants;
    using GuessTheNumber.Web.Models.Response;
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

    public static partial class ConvertingExtensions
    {
        public static GuessResponse ToResponse(this AttemptResultContract attemptContract)
        {
            string message = attemptContract.Result switch
            {
                GameAttemptResults.LESS => GameMessages.GuessIsLessThanNumber,
                GameAttemptResults.MORE => GameMessages.GuessIsGreaterThanNumber,
                GameAttemptResults.WIN => GameMessages.GuessIsCorrect
            };
            return new GuessResponse { Number = attemptContract.Number, Result = message };
        }
    }
}