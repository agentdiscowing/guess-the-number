namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
    using GuessTheNumber.Web.Models.Response;
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
            return Ok(new GameStartedResponse(number));
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
            var gameState = this.gameService.GetGameState(this.HttpContext.GetCurrentGameId());
            return Ok(gameState.ToResponse());
        }
    }
}