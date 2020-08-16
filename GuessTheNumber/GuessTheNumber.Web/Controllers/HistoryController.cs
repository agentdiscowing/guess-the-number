namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService historyService;

        public HistoryController(IHistoryService historyService)
        {
            this.historyService = historyService;
        }

        [HttpGet("{page}")]
        public IActionResult GetGames(int page, [FromBody] int gamesPerPage)
        {
            var gameList = this.historyService.GetGameHistory(page, gamesPerPage);
            return Ok(gameList);
        }

        [HttpGet("guesses")]
        public IActionResult GetGameGuesses([FromBody] int gameId)
        {
            var gameList = this.historyService.GetGameGuesses(gameId);
            return Ok(gameList);
        }
    }
}