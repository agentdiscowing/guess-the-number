namespace GuessTheNumber.Web
{
    using GuessTheNumber.Web.Contracts;
    using GuessTheNumber.Web.Models.Response;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<AuthSuccessResponse> LoginAsync(string email, string password);

        Task<AuthSuccessResponse> RegisterAsync(NewUserContract newUser);
    }
}