namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoryController : ControllerBase
    {
        private readonly IGameService gameService;

        public HistoryController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet("history/{page}")]
        public IActionResult GetGameHistory(int page, [FromBody] int gamesPerPage)
        {
            var gameList = this.gameService.GetGameHistory(page, gamesPerPage, this.HttpContext.GetUserId());
            return Ok(gameList);
        }
    }
}