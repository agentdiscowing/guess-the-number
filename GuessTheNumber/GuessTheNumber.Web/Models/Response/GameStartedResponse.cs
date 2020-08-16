using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumber.Web.Models.Response
{
    public class GameStartedResponse
    {
        public GameStartedResponse(int number)
        {
            this.Number = number;
        }

        public int Number { get; set; }

        public string Message => $"Game with number {this.Number} is started";
    }
}