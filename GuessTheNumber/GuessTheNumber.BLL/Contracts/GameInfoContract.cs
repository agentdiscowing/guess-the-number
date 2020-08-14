namespace GuessTheNumber.BLL.Contracts
{
    using System;

    public class GameInfoContract
    {
        public TimeSpan Length { get; set; }

        public int Number { get; set; }

        public bool WonByUser { get; set; }

        public bool ParticipatedByUser { get; set; }
    }
}