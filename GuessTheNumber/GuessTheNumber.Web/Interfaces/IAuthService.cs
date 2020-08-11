namespace GuessTheNumber.Web
{
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.Web.Models.Response;

    public interface IAuthService
    {
        AuthSuccessResponse Login(string email, string password);

        AuthSuccessResponse Register(NewUserContract newUser);
    }
}