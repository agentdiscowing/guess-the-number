namespace GuessTheNumber.DAL.Entities
{
    using System;

    public class Game : BaseEntity
    {
        public int OwnerId { get; set; }

        public int Number { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int WinnerId { get; set; }
    }
}