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
    using GuessTheNumber.Web.Models.Request;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService authService;

        private readonly IGameService gameService;

        private CurrentGame currentGame;

        private readonly IProducer producer;

        public AccountController(IAuthService authenticationService, IGameService gameService, CurrentGame currentGame, IProducer producer)
        {
            this.authService = authenticationService;
            this.gameService = gameService;
            this.currentGame = currentGame;
            this.producer = producer;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserRequest creds)
        {
            var authResult = await this.authService.LoginAsync(creds.Email, creds.Password);

            return Ok(authResult);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] NewUserRequest newUser)
        {
            var authResult = await this.authService.RegisterAsync(newUser.ToContract());

            return Ok(authResult);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            this.gameService.LeaveGame(this.HttpContext.GetUserId(), this.currentGame.CurrentGameId);
            if (this.currentGame.CurrentGameOwnerId == this.HttpContext.GetUserId())
            {
                this.producer.Produce<Null, GameOver>("gameEvents", null, new GameOver(), new KafkaSerializer<GameOver>());
            }

            return Ok();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest)
        {
            var authResult = await this.authService.RefreshTokenAsync(refreshTokenRequest.AccessToken, refreshTokenRequest.RefreshToken);

            return Ok(authResult);
        }
    }
}