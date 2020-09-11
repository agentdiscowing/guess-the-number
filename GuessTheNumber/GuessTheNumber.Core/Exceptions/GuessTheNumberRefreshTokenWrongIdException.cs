namespace GuessTheNumber.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using GuessTheNumber.Core.Enums;
    using GuessTheNumber.Core.Resources;

public class GuessTheNumberRefreshTokenWrongIdException : GuessTheNumberException
{
    public GuessTheNumberRefreshTokenWrongIdException()
    : base(ErrorMessages.GuessTheNumberRefreshTokenWrongIdException)
    {
    }

    public GuessTheNumberRefreshTokenWrongIdException(string message)
        : base(message)
    {
    }

    public GuessTheNumberRefreshTokenWrongIdException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected GuessTheNumberRefreshTokenWrongIdException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public override int Code => (int)ExceptionEnums.Authentication.RefreshTokenWrongId;
    }
}