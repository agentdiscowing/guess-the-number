namespace GuessTheNumber.Web.Extensions.ConvertingExtensions
{
    using System;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.Web.Models.Request;

    public static partial class ConvertingExtensions
    {
        public static CommentContract ToContract(this NewCommentRequest commentRequest, string username)
        {
            return new CommentContract
            {
                Username = username,
                PostDate = DateTime.Now,
                Text = commentRequest.Text
            };
        }
    }
}