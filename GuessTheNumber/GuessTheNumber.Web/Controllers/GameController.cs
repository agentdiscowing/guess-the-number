namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

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

        [HttpPost("start")]
        public IActionResult StartGame(int number)
        {
            int currentGameNumber = this.gameService.StartGame(this.HttpContext.GetUserId().Value, number);
            return Ok($"Game with number {currentGameNumber} is started!");
        }

        [HttpPost("guess")]
        public IActionResult GuessTheNumber(int number)
        {
            var guessResult = this.gameService.MakeAttempt(this.HttpContext.GetUserId().Value, number);
            // do response insted of just message
            string message = guessResult == GameAttemptResults.WIN ? "You guessed the number correctly. Game is over." : $"Your number is {guessResult} than needed.";
            return Ok(message);
        }

        [HttpPost("check")]
        public IActionResult CheckActiveGame()
        {
            var gameIsStarted = this.gameService.GameIsStarted();
            return Ok(gameIsStarted);
        }
    }
}