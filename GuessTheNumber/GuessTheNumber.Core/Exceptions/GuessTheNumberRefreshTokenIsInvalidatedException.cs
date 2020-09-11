namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.Resources;

    public class GuessTheNumberRefreshTokenIsInvalidatedException : GuessTheNumberException
    {
        public GuessTheNumberRefreshTokenIsInvalidatedException()
        : base(ErrorMessages.GuessTheNumberRefreshTokenIsInvalidatedException)
        {
        }

        public GuessTheNumberRefreshTokenIsInvalidatedException(string message)
            : base(message)
        {
        }

        public GuessTheNumberRefreshTokenIsInvalidatedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberRefreshTokenIsInvalidatedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.RefreshTokenIsInvalidated;
    }

}