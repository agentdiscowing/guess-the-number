namespace GuessTheNumber.API
{
    using GuessTheNumber.BLL.Contracts;

    public interface IAuthManager
    {
        string Authenticate(ShortUserInfoContract user);
    }
}