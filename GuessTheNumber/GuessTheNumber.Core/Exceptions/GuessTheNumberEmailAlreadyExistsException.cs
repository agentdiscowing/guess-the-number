﻿namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.Resources;

    public class GuessTheNumberEmailAlreadyExistsException : GuessTheNumberException
    {
        public GuessTheNumberEmailAlreadyExistsException()
        : base(ErrorMessages.GuessTheNumberEmailAlreadyExistsException)
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