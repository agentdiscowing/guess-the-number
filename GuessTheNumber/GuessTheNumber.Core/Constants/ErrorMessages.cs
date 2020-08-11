namespace GuessTheNumber.Core.Constants
{
    public static class ErrorMessages
    {
        public const string ValidationError = "One or more validation errors occured";

        public const string UnhandledException = "Sorry, something went wrong on the server side. Try again later";

        public const string GuessTheNumberException = "Application logic failed.";

        public const string GuessTheNumberEmailAlreadyExistsException = "User with this email is already registered on the app";

        public const string GuessTheNumberUserDoesNotExistException = "User with this username or email is not registered on the app.";

        public const string GuessTheNumberInvalidPasswordException = "Invalid password was entered";

        public const string GuessTheNumberUsernameAlreadyExistsException = "User with this email is already registered on the app";

        public const string GuessTheNumberUserWasNotCreatedException = "User was not registrered on the app";
    }
}