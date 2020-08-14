namespace GuessTheNumber.Web
{
    using System.Threading.Tasks;
    using GuessTheNumber.Web.Contracts;

    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string password);

        Task<string> RegisterAsync(NewUserContract newUser);
    }
}