namespace GuessTheNumber.Web.Interfaces
{
    using System.Threading.Tasks;
    using GuessTheNumber.Web.Models.Response;

    public interface ICommentClient
    {
        Task NewCommentAdded(CommentResponse newComment);

        Task CommentModified(EditedCommentResponse editedComment);

        Task CommentDeleted(int commentId);
    }
}