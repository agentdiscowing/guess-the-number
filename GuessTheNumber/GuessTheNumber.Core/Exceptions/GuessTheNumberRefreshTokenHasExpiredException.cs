namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.Resources;

    public class GuessTheNumberRefreshTokenHasExpiredException : GuessTheNumberException
    {
        public GuessTheNumberRefreshTokenHasExpiredException()
        : base(ErrorMessages.GuessTheNumberRefreshTokenHasExpiredException)
        {
        }

        public GuessTheNumberRefreshTokenHasExpiredException(string message)
            : base(message)
        {
        }

        public GuessTheNumberRefreshTokenHasExpiredException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberRefreshTokenHasExpiredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.RefreshTokenHasExpired;
    }

}