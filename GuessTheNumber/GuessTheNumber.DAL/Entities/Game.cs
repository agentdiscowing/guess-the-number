using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumber.DAL.Entities
{
    public class Game: BaseEntity
    {
        public int OwnerId { get; set; }

        public int Number { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int WinnerId { get; set; }
    }
}
