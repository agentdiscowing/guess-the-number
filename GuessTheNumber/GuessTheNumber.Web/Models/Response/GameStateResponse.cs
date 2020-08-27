namespace GuessTheNumber.Web.Models.Response
{
    public class GameStateResponse
    {
        public GameStateResponse(string message, string state)
        {
            this.Message = message;
            this.State = state;
        }

        public string Message { get; set; }

        public string State { get; set; }
    }
}