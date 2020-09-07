namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
    using GuessTheNumber.Web.Models.Request;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost("send")]
        public IActionResult SendComment(NewCommentRequest comment)
        {
            var newComment = this.commentService.SendComment(comment.ToContract(this.HttpContext.User.Identity.Name));

            return Ok(newComment);
        }

        [HttpDelete("delete/{commentId}")]
        public IActionResult DeleteComment(int commentId)
        {
            this.commentService.DeleteComment(commentId, this.HttpContext.User.Identity.Name);

            return Ok();
        }

        [HttpPut("edit/{commentId}")]
        public IActionResult EditComment(int commentId, [FromBody] NewCommentRequest editedComment)
        {
            this.commentService.EditComment(commentId, this.HttpContext.User.Identity.Name, editedComment.Text);

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