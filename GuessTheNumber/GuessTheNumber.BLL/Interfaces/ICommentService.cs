namespace GuessTheNumber.BLL.Interfaces
{
    using GuessTheNumber.BLL.Contracts;
    using System.Collections.Generic;

    public interface ICommentService
    {
        int SendComment(CommentContract comment);

        void DeleteComment(int commentId, string username);

        void EditComment(int commentId, string username, string newContent);

        IEnumerable<CommentContract> GetComments();
    }
}