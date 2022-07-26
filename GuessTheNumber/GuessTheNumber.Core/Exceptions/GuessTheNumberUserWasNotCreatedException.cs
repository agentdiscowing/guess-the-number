﻿namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.Resources;

    public class GuessTheNumberUserWasNotCreatedException : GuessTheNumberException
    {
        public GuessTheNumberUserWasNotCreatedException()
        : base(ErrorMessages.GuessTheNumberUserWasNotCreatedException)
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