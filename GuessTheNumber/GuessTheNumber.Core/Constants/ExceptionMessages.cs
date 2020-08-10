namespace GuessTheNumber.Core.Constants
{
    public static class ExceptionMessages
    {
        public static string GuessTheNumberException { get; private set; } = "Application logic failed. See the inner exception for more details.";

        public static string GuessTheNumberEmailAlreadyExistsException { get; private set; } = "User with this email is already registered on the app";

        public static string GuessTheNumberUserDoesNotExistException { get; private set; } = "User with this username or email is not registered on the app.";
    }
}