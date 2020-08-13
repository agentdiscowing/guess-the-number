namespace GuessTheNumber.Web
{
    using GuessTheNumber.Web.Contracts;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string password);

        Task<string> RegisterAsync(NewUserContract newUser);
    }
}