using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumber.DAL.Entities
{
    public class Attempt
    {
        public int UserId { get; set; }

        public int GameId { get; set; }

        public int Number { get; set; }
    }
}
