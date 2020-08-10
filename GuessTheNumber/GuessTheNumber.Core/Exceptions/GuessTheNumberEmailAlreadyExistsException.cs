namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Constants;
    using GuessTheNumber.Core.Enums;

    public class GuessTheNumberEmailAlreadyExistsException : GuessTheNumberException
    {
        public GuessTheNumberEmailAlreadyExistsException()
        : base(ExceptionMessages.GuessTheNumberEmailAlreadyExistsException)
        {
        }

        public GuessTheNumberEmailAlreadyExistsException(string message)
            : base(message)
        {
        }

        public GuessTheNumberEmailAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberEmailAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.EmailAlreadyExists;
    }
}