namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.Resources;

    public class GuessTheNumberGameOverException : GuessTheNumberException
    {
        public GuessTheNumberGameOverException()
        : base(ErrorMessages.GuessTheNumberGameOverException)
        {
        }

        public GuessTheNumberGameOverException(string message)
            : base(message)
        {
        }

        public GuessTheNumberGameOverException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberGameOverException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Game.GameOver;
    }
}