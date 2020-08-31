namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
    using GuessTheNumber.Web.Global;
    using GuessTheNumber.Web.Models.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        private CurrentGame currentGame;

        public GameController(IGameService gameService, CurrentGame currentGame)
        {
            this.gameService = gameService;
            this.currentGame = currentGame;
        }

        [HttpPost("start/{number}")]
        public IActionResult StartGame(int number)
        {
            int currentGameId = this.gameService.StartGame(this.HttpContext.GetUserId(), number, this.currentGame.CurrentGameId);
            this.currentGame.CurrentGameId = currentGameId;
            return Ok(new GameStartedResponse(number));
        }

        [HttpPost("guess/{number}")]
        public IActionResult GuessTheNumber(int number)
        {
            var guessResult = this.gameService.MakeGuess(this.HttpContext.GetUserId(), number, this.currentGame.CurrentGameId);
            return Ok(guessResult.ToResponse());
        }

        [HttpGet("state")]
        public IActionResult GetState()
        {
            var gameState = this.gameService.GetGameState(this.currentGame.CurrentGameId);
            return Ok(gameState.ToResponse());
        }
    }
}