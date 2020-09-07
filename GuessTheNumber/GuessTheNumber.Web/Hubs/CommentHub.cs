namespace GuessTheNumber.Web.Hubs
{
    using GuessTheNumber.Web.Interfaces;
    using GuessTheNumber.Web.Models.Response;
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

    public class CommentHub : Hub<ICommentClient>
    {
        public Task NewCommentAdded(CommentResponse newComment)
        {
            return this.Clients.Others.NewCommentAdded(newComment);
        }
    }
}