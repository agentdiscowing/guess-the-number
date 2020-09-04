namespace GuessTheNumber.Web.Global
{
    public class CurrentGame
    {
        public int? CurrentGameId { get; set; }

        public string CurrentGameOwnerId { get; set; }

        public void SetNewGame(int? gameId, string ownerId)
        {
            this.CurrentGameId = gameId;
            this.CurrentGameOwnerId = ownerId;
        }

        public bool IsOwner(string userId)
        {
            return this.CurrentGameOwnerId == userId;
        }
    }
}