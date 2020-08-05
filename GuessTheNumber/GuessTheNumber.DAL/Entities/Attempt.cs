namespace GuessTheNumber.DAL.Entities
{
    public class Attempt
    {
        public int UserId { get; set; }

        public int GameId { get; set; }

        public int Number { get; set; }

        public User User { get; set; }

        public Game Game { get; set; }
    }
}