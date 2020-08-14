namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpPost("start/{number}")]
        public IActionResult StartGame(int number)
        {
            int currentGameId = this.gameService.StartGame(this.HttpContext.GetUserId(), number, this.HttpContext.GetCurrentGameId());
            this.HttpContext.Session.SetString("GameId", currentGameId.ToString());
            return Ok($"Game with number {number} is started!");
        }

        [HttpPost("guess/{number}")]
        public IActionResult GuessTheNumber(int number)
        {
            var guessResult = this.gameService.MakeGuess(this.HttpContext.GetUserId(), number, this.HttpContext.GetCurrentGameId());
            return Ok(guessResult.ToResponse());
        }

        [HttpGet("state")]
        public IActionResult GetState()
        {
            var guessResult = this.gameService.GetGameState(this.HttpContext.GetCurrentGameId());
            return Ok(guessResult.ToResponse());
        }

        // implemented pagination here
        [HttpGet("history/{page}")]
        public IActionResult GetGameHistory(int page, [FromBody] int gamesPerPage)
        {
            var gameList = this.gameService.GetGameHistory(page, gamesPerPage, this.HttpContext.GetUserId());
            return Ok(gameList);
        }
    }
}