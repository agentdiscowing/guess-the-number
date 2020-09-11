namespace GuessTheNumber.Web
{
    using System.Threading.Tasks;
    using GuessTheNumber.Web.Contracts;

    public interface IAuthService
    {
        Task<AuthenticationResult> LoginAsync(string email, string password);

        Task<AuthenticationResult> RegisterAsync(NewUserContract newUser);

        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}