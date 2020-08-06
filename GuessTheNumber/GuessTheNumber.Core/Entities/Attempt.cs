namespace GuessTheNumber.Core.Entities
{
    public class Attempt
    {
        public int UserId { get; set; }

        public int GameId { get; set; }

        public int Number { get; set; }

        public virtual User User { get; set; }

        public virtual Game Game { get; set; }
    }
}