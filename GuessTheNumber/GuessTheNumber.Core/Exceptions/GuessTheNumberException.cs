namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.Resources;

    public class GuessTheNumberException : Exception
    {
        public GuessTheNumberException()
        : base(ErrorMessages.GuessTheNumberException)
        {
        }

        public GuessTheNumberException(string message)
            : base(message)
        {
        }

        public GuessTheNumberException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public virtual int Code => (int)ExceptionEnums.Global.CustomException;
    }
}