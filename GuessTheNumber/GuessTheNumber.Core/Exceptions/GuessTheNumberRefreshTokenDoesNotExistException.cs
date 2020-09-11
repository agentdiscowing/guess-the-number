namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.Resources;

    public class GuessTheNumberRefreshTokenDoesNotExistException : GuessTheNumberException
    {
        public GuessTheNumberRefreshTokenDoesNotExistException()
        : base(ErrorMessages.GuessTheNumberRefreshTokenDoesNotExistException)
        {
        }

        public GuessTheNumberRefreshTokenDoesNotExistException(string message)
            : base(message)
        {
        }

        public GuessTheNumberRefreshTokenDoesNotExistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberRefreshTokenDoesNotExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.RefreshTokenDoesNotExist;
    }

}