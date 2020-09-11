namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.Resources;

    public class GuessTheNumberRefreshTokenIsUsedException : GuessTheNumberException
    {
        public GuessTheNumberRefreshTokenIsUsedException()
        : base(ErrorMessages.GuessTheNumberRefreshTokenIsUsedException)
        {
        }

        public GuessTheNumberRefreshTokenIsUsedException(string message)
            : base(message)
        {
        }

        public GuessTheNumberRefreshTokenIsUsedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberRefreshTokenIsUsedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.RefreshTokenIsUsed;
    }

}