﻿namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Constants;
    using GuessTheNumber.Core.Enums;

    public class GuessTheNumberUsernameAlreadyExistsException : GuessTheNumberException
    {
        public GuessTheNumberUsernameAlreadyExistsException()
        : base(ExceptionMessages.GuessTheNumberUsernameAlreadyExistsException)
        {
        }

        public GuessTheNumberUsernameAlreadyExistsException(string message)
            : base(message)
        {
        }

        public GuessTheNumberUsernameAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GuessTheNumberUsernameAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override int Code => (int)ExceptionEnums.Authentication.UsernameAlreadyExists;
    }
}