namespace GuessTheNumber.Web.Contracts
{
    public class AuthenticationResult
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}