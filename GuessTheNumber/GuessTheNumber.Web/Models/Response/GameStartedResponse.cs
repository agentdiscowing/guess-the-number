namespace GuessTheNumber.Web.Models.Response
{
    public class GameStartedResponse
    {
        public GameStartedResponse(int number, string owner)
        {
            this.Number = number;
            this.OwnerUsername = owner;
        }

        public int Number { get; set; }

        public string OwnerUsername { get; set; }

        public string Message => $"Game with number {this.Number} is started";
    }
}