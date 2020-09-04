namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
    using GuessTheNumber.Web.Global;
    using GuessTheNumber.Web.Hubs;
    using GuessTheNumber.Web.Interfaces;
    using GuessTheNumber.Web.Models.Request;
    using GuessTheNumber.Web.Models.Response;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService authService;

        private readonly IGameService gameService;

        private CurrentGame currentGame;

        private readonly IHubContext<GameHub, IGameClient> gameHubContext;

        public AccountController(IAuthService authenticationService, IGameService gameService, CurrentGame currentGame, IHubContext<GameHub, IGameClient> gameHubContext)
        {
            this.authService = authenticationService;
            this.gameService = gameService;
            this.currentGame = currentGame;
            this.gameHubContext = gameHubContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserRequest creds)
        {
            var token = this.authService.LoginAsync(creds.Email, creds.Password);

            return Ok(new AuthSuccessResponse(token.Result));
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] NewUserRequest newUser)
        {
            var token = this.authService.RegisterAsync(newUser.ToContract());

            return Ok(new AuthSuccessResponse(token.Result));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            this.gameService.LeaveGame(this.HttpContext.GetUserId(), this.currentGame.CurrentGameId);
            if (this.currentGame.CurrentGameOwnerId == this.HttpContext.GetUserId())
            {
                await this.gameHubContext.Clients.All.SendGameOverMessage();
            }

            return Ok();
        }
    }
}