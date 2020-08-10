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
            EmailAlreadyExists = 1101,
            UsernameAlreadyExists = 1102,
            InvalidPassword = 1103,
            UserDoesNotExist = 1104,
            UserWasNotCreated = 1105
        }
    }
}