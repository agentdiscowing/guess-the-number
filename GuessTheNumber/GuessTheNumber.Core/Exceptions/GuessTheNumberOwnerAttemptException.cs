namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Constants;
    using GuessTheNumber.Core.Enums;

    public class GuessTheNumberOwnerAttemptException : GuessTheNumberException
    {
        public GuessTheNumberOwnerAttemptException()
        : base(ErrorMessages.GuessTheNumberOwnerAttemptException)
        {
        }

        public GuessTheNumberOwnerAttemptException(string message)
            : base(message)
        {
        }

        public GuessTheNumberOwnerAttemptException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberOwnerAttemptException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Game.OwnerAttempt;
    }
}
