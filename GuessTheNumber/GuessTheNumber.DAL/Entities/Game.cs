namespace GuessTheNumber.DAL.Entities
{
    
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    public class Game : BaseEntity
    {
        public string OwnerId { get; set; }

        public int Number { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string WinnerId { get; set; }

        public virtual IdentityUser Winner { get; set; }

        public virtual IdentityUser Owner { get; set; }

        public virtual ICollection<Guess> Attempts { get; set; }
    }
}