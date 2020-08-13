using GuessTheNumber.Core.Enums;
using GuessTheNumber.Core.Resources;
using System;
using System.Runtime.Serialization;

namespace GuessTheNumber.Core.Exceptions
{
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

        public virtual int Code => (int)ExceptionEnums.Game.GameOver;
    }
}