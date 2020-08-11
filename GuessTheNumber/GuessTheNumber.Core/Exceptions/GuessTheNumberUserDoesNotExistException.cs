namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Constants;
    using GuessTheNumber.Core.Enums;

    public class GuessTheNumberUserDoesNotExistException : GuessTheNumberException
    {
        public GuessTheNumberUserDoesNotExistException()
        : base(ErrorMessages.GuessTheNumberUserDoesNotExistException)
        {
        }

        public GuessTheNumberUserDoesNotExistException(string message)
            : base(message)
        {
        }

        public GuessTheNumberUserDoesNotExistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberUserDoesNotExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.UserDoesNotExist;
    }
}
