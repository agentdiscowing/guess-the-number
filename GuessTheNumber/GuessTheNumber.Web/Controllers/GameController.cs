namespace GuessTheNumber.Web.Controllers
{
    using System.Threading.Tasks;
    using Confluent.Kafka;
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Kafka;
    using GuessTheNumber.Kafka.Interfaces;
    using GuessTheNumber.Web.Events;
    using GuessTheNumber.Web.Extensions;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
    using GuessTheNumber.Web.Global;
    using GuessTheNumber.Web.Interfaces;
    using GuessTheNumber.Web.Models.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using static GuessTheNumber.Core.Enums.GameLogicEnums;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        private CurrentGame currentGame;

        private IProducer producer;

        public GameController(IGameService gameService, CurrentGame currentGame, IProducer producer)
        {
            this.gameService = gameService;
            this.currentGame = currentGame;
            this.producer = producer;
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
                this.producer.Produce<Null, GameEvent>(
                    "gameEvents",
                    null,
                    new GameEvent { EventType = 1, Value = JsonConvert.SerializeObject(new GameWon { WinnerUsername = this.HttpContext.User.Identity.Name }) },
                    new KafkaSerializer<GameEvent>());
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