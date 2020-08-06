namespace GuessTheNumber.API
{
    public interface IAuthManager
    {
        string Authenticate(string username, string password);
    }
}