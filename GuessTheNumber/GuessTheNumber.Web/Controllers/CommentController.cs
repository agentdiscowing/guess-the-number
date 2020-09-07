namespace GuessTheNumber.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
    using GuessTheNumber.Web.Hubs;
    using GuessTheNumber.Web.Interfaces;
    using GuessTheNumber.Web.Models.Request;
    using GuessTheNumber.Web.Models.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;

        private readonly IHubContext<CommentHub, ICommentClient> commentHubContext;

        public CommentController(ICommentService commentService, IHubContext<CommentHub, ICommentClient> hubContext)
        {
            this.commentService = commentService;
            this.commentHubContext = hubContext;
        }

        [HttpPost("send")]
        public IActionResult SendComment(NewCommentRequest comment)
        {
            var newComment = this.commentService.SendComment(comment.ToContract(this.HttpContext.User.Identity.Name));

            return Ok(newComment);
        }

        [HttpDelete("delete/{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            this.commentService.DeleteComment(commentId, this.HttpContext.User.Identity.Name);

            await this.commentHubContext.Clients.All.CommentDeleted(commentId);

            return Ok();
        }

        [HttpPut("edit/{commentId}")]
        public async Task<IActionResult> EditComment(int commentId, [FromBody] NewCommentRequest editedComment)
        {
            this.commentService.EditComment(commentId, this.HttpContext.User.Identity.Name, editedComment.Text);

            await this.commentHubContext.Clients.All.CommentModified(new EditedCommentResponse
            {
                Id = commentId,
                Text = editedComment.Text
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetCommentSection()
        {
            var comments = this.commentService.GetComments().Select(c => c.ToResponse(this.HttpContext.User.Identity.Name));

            return Ok(comments);
        }
    }
}