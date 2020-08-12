namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
    using GuessTheNumber.Web.Models.Response;
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

        [HttpPost("start/{number}")]
        public IActionResult StartGame(int number)
        {
            int currentGameNumber = this.gameService.StartGame(this.HttpContext.GetUserId().Value, number);
            return Ok($"Game with number {currentGameNumber} is started!");
        }

        [HttpPost("guess/{number}")]
        public IActionResult GuessTheNumber(int number)
        {
            var guessResult = this.gameService.MakeAttempt(this.HttpContext.GetUserId().Value, number);
            return Ok(guessResult.ToResponse());
        }

        [HttpPost("check")]
        public IActionResult CheckActiveGame()
        {
            var gameIsStarted = this.gameService.GameIsStarted();
            return Ok(gameIsStarted);
        }
    }
}