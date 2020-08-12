namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Resources;
    using GuessTheNumber.Core.Enums;

    public class GuessTheNumberInvalidPasswordException : GuessTheNumberException
    {
        public GuessTheNumberInvalidPasswordException()
        : base(ErrorMessages.GuessTheNumberInvalidPasswordException)
        {
        }

        public GuessTheNumberInvalidPasswordException(string message)
            : base(message)
        {
        }

        public GuessTheNumberInvalidPasswordException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberInvalidPasswordException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.InvalidPassword;
    }
}
