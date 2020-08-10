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
            InvalidPassword = 403,
            UserDoesNotExist = 404,
            UserWasNotCreated = 404
        }
    }
}