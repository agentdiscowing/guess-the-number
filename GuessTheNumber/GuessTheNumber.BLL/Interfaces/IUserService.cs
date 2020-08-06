namespace GuessTheNumber.BLL.Interfaces
{
    using GuessTheNumber.BLL.Contracts;

    public interface IUserService
    {
        bool Login(LoginUserContract creds);

        ShortUserInfoContract Register(NewUserContract newUser);
    }
}