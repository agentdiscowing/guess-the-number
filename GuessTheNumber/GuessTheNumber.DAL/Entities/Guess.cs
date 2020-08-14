namespace GuessTheNumber.DAL.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class Guess
    {
        public string UserId { get; set; }

        public int GameId { get; set; }

        public int Number { get; set; }

        public virtual IdentityUser User { get; set; }

        public virtual Game Game { get; set; }
    }
}