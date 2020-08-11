namespace GuessTheNumber.Web.Models.Response
{
    public class AuthSuccessResponse
    {
        public AuthSuccessResponse(string token)
        {
            this.Token = token;
        }

        public string Token { get; set; }
    }
}