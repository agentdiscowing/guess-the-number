namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.Resources;

    public class GuessTheNumberNoActiveGameException : GuessTheNumberException
    {
        public GuessTheNumberNoActiveGameException()
        : base(ErrorMessages.GuessTheNumberNoActiveGameException)
        {
        }

        public GuessTheNumberNoActiveGameException(string message)
            : base(message)
        {
        }

        public GuessTheNumberNoActiveGameException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberNoActiveGameException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Game.NoActiveGame;
    }
}