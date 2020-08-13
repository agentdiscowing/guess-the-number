
using Microsoft.AspNetCore.Identity;

namespace GuessTheNumber.DAL.Entities
{
    public class Attempt
    {
        public string UserId { get; set; }

        public int GameId { get; set; }

        public int Number { get; set; }

        public virtual IdentityUser User { get; set; }

        public virtual Game Game { get; set; }
    }
}