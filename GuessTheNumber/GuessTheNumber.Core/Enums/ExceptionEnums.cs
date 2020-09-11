namespace GuessTheNumber.Core.Enums
{
    public class ExceptionEnums
    {
        public enum Global
        {
            CustomException = 1000
        }

        public enum Authentication
        {
            EmailAlreadyExists = 409,
            UsernameAlreadyExists = 409,
            InvalidPassword = 401,
            UserDoesNotExist = 404,
            UserWasNotCreated = 404,
            RefreshTokenDoesNotExist = 401,
            RefreshTokenHasExpired = 401,
            RefreshTokenIsUsed = 401,
            RefreshTokenIsInvalidated = 401,
            RefreshTokenWrongId = 401
        }

        public enum Game
        {
            NoActiveGame = 404,
            OwnerAttempt = 403,
            GameOver = 400
        }
    }
}