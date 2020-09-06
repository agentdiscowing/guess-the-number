namespace GuessTheNumber.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.BLL.Interfaces;

    public class CommentService : ICommentService
    {
        private int nextId = 1;

        private IList<CommentContract> comments;

        public CommentService()
        {
            this.comments = new List<CommentContract>();
        }

        public void DeleteComment(int commentId, string username)
        {
            var comment = this.comments.SingleOrDefault(comment => comment.Id == commentId);

            if (comment.Username != username)
            {
                throw new UnauthorizedAccessException();
            }

            this.comments.Remove(comment);
        }

        public void EditComment(int commentId, string username, string newContent)
        {
            var comment = this.comments.SingleOrDefault(comment => comment.Id == commentId);

            if (comment.Username != username)
            {
                throw new UnauthorizedAccessException();
            }

            comment.Text = newContent;

        }

        public IEnumerable<CommentContract> GetComments()
        {
            return this.comments.OrderBy(comment => comment.PostDate);
        }

        public int SendComment(CommentContract comment)
        {
            comment.Id = this.nextId;

            ++this.nextId;

            this.comments.Add(comment);

            return comment.Id;
        }
    }
}