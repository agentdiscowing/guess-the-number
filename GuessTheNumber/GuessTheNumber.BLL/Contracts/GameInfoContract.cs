namespace GuessTheNumber.BLL.Contracts
{
    using System;

    public class GameInfoContract
    {
        public int Id { get; set; }

        public TimeSpan Length { get; set; }

        public int Number { get; set; }

        public string WinnerId { get; set; }

        public string[] ParticipatsIds { get; set; }

        public string OwnerId { get; set; }
    }
}