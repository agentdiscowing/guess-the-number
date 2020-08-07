using GuessTheNumber.BLL.Contracts;

namespace GuessTheNumber.API
{
    public interface IAuthManager
    {
        string Authenticate(ShortUserInfoContract user);
    }
}