namespace GuessTheNumber.Web.Models.Response
{
    using System;

    public class CommentResponse
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime PostDate { get; set; }

        public string Text { get; set; }

        public bool IsOwned { get; set; }
    }
}