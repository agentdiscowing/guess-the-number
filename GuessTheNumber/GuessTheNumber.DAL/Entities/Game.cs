namespace GuessTheNumber.DAL.Entities
{
    using System;
    using System.Collections.Generic;

    public class Game : BaseEntity
    {
        public int OwnerId { get; set; }

        public int Number { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int? WinnerId { get; set; }

        public User Winner { get; set; }

        public User Owner { get; set; }

        public ICollection<Attempt> Attempts { get; set; }
    }
}