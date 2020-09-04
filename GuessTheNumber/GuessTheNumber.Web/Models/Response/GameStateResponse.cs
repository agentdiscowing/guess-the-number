namespace GuessTheNumber.Web.Models.Response
{
    public class GameStateResponse
    {
        public GameStateResponse(string message, string state, bool isOwner)
        {
            this.Message = message;
            this.State = state;
            this.IsOwner = isOwner;
        }

        public string Message { get; set; }

        public string State { get; set; }

        public bool IsOwner { get; set; }
    }
}