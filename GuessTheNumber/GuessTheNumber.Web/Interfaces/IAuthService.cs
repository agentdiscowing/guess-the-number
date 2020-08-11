namespace GuessTheNumber.Web
{
    using GuessTheNumber.BLL.Contracts;

    public interface IAuthService
    {
        string Login(string email, string password);

        string Register(NewUserContract newUser);
    }
}