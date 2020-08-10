namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Constants;
    using GuessTheNumber.Core.Enums;

    public class GuessTheNumberUserWasNotCreatedException : GuessTheNumberException
    {
        public GuessTheNumberUserWasNotCreatedException()
        : base(ExceptionMessages.GuessTheNumberUserWasNotCreatedException)
        {
        }

        public GuessTheNumberUserWasNotCreatedException(string message)
            : base(message)
        {
        }

        public GuessTheNumberUserWasNotCreatedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberUserWasNotCreatedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.UserWasNotCreated;
    }
}
