namespace GuessTheNumber.BLL.Contracts
{
    using System;

    public class CommentContract
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime PostDate { get; set; }

        public string Text { get; set; }
    }
}