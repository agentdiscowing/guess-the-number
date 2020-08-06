namespace GuessTheNumber.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public class Game : BaseEntity
    {
        public int OwnerId { get; set; }

        public int Number { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int? WinnerId { get; set; }

        public virtual User Winner { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Attempt> Attempts { get; set; }
    }
}