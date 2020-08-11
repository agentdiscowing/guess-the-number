namespace GuessTheNumber.Core.Constants
{
    public static class ErrorMessages
    {
        public static string ValidationError { get; private set; } = "One or more validation errors occured";

        public static string UnhandledException { get; private set; } = "Sorry, something went wrong on the server side. Try again later";

        public static string GuessTheNumberException { get; private set; } = "Application logic failed.";

        public static string GuessTheNumberEmailAlreadyExistsException { get; private set; } = "User with this email is already registered on the app";

        public static string GuessTheNumberUserDoesNotExistException { get; private set; } = "User with this username or email is not registered on the app.";

        public static string GuessTheNumberInvalidPasswordException { get; private set; } = "Invalid password was entered";

        public static string GuessTheNumberUsernameAlreadyExistsException { get; private set; } = "User with this email is already registered on the app";

        public static string GuessTheNumberUserWasNotCreatedException { get; private set; } = "User was not registrered on the app";

        public static string GuessTheNumberNoActiveGameException { get; private set; } = "There is no active game right now";

        public static string GuessTheNumberOwnerAttemptException { get; private set; } = "Making attempt on one's own game is not allowed";
    }
}