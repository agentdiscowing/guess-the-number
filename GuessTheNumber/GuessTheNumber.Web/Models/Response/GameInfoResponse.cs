namespace GuessTheNumber.Web.Models.Response
{
    using System;

    public class GameInfoResponse
    {
        public int Id { get; set; }

        public string Length { get; set; }

        public int Number { get; set; }

        public bool IsWinner { get; set; }

        public bool IsParticipant { get; set; }

        public bool IsOwner { get; set; }
    }
}