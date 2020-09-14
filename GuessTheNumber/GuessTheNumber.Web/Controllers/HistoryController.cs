namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
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
        public IActionResult GetGames(int page, int gamesPerPage)
        {
            var gameList = this.historyService.GetGameHistory(page, gamesPerPage);
            return Ok(gameList.ToResponseList(this.HttpContext.GetUserId()));
        }

        [HttpGet("guesses")]
        public IActionResult GetGameGuesses(int gameId)
        {
            var guessesList = this.historyService.GetGameGuesses(gameId);
            return Ok(guessesList);
        }
    }
}