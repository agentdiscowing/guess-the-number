namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
    using GuessTheNumber.Web.Global;
    using GuessTheNumber.Web.Hubs;
    using GuessTheNumber.Web.Interfaces;
    using GuessTheNumber.Web.Models.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        private readonly IHubContext<GameHub, IGameClient> gameHubContext;

        private CurrentGame currentGame;

        public GameController(IGameService gameService, IHubContext<GameHub, IGameClient> gameHubContext, CurrentGame currentGame)
        {
            this.gameService = gameService;
            this.gameHubContext = gameHubContext;
            this.currentGame = currentGame;
        }

        [HttpPost("start/{number}")]
        public IActionResult StartGame(int number)
        {
            int currentGameId = this.gameService.StartGame(this.HttpContext.GetUserId(), number, this.currentGame.CurrentGameId);
            this.currentGame.SetNewGame(currentGameId, this.HttpContext.GetUserId());
            return Ok(new GameStartedResponse(number, this.HttpContext.User.Identity.Name));
        }

        [HttpPost("guess/{number}")]
        public async Task<IActionResult> GuessTheNumberAsync(int number)
        {
            var guessResult = this.gameService.MakeGuess(this.HttpContext.GetUserId(), number, this.currentGame.CurrentGameId);
            if (guessResult.Result == GameAttemptResults.WIN)
            {
                await this.gameHubContext.Clients.All.SendGameWonMessage(this.HttpContext.User.Identity.Name);
            }
            return Ok(guessResult.ToResponse());
        }

        [HttpGet("state")]
        public IActionResult GetState()
        {
            var gameState = this.gameService.GetGameState(this.currentGame.CurrentGameId);
            return Ok(gameState.ToResponse(this.currentGame.IsOwner(this.HttpContext.GetUserId())));
        }
    }
}