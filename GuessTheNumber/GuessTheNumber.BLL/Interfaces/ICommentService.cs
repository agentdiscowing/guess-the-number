namespace GuessTheNumber.BLL.Interfaces
{
    using GuessTheNumber.BLL.Contracts;
    using System.Collections.Generic;

    public interface ICommentService
    {
        CommentContract SendComment(CommentContract comment);

        void DeleteComment(int commentId, string username);

        void EditComment(int commentId, string username, string newContent);

        IEnumerable<CommentContract> GetComments();
    }
}