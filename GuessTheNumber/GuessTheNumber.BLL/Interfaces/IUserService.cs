namespace GuessTheNumber.BLL.Interfaces
{
    using GuessTheNumber.BLL.Contracts;

    public interface IUserService
    {
        ShortUserInfoContract Login(LoginUserContract creds);

        ShortUserInfoContract Register(NewUserContract newUser);
    }
}