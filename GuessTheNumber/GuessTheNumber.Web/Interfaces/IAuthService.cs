namespace GuessTheNumber.Web
{
    using GuessTheNumber.BLL.Contracts;

    public interface IAuthService
    {
        string Login(LoginUserContract creds);

        string Register(NewUserContract newUser);
    }
}