namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
    using GuessTheNumber.Web.Models.Request;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService authService;

        private readonly IGameService gameService;

        public AccountController(IAuthService authenticationService, IGameService gameService)
        {
            this.authService = authenticationService;
            this.gameService = gameService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserRequest creds)
        {
            var authResult = this.authService.Login(creds.Email, creds.Password);

            return Ok(authResult);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] NewUserRequest newUser)
        {
            var registrationResult = this.authService.Register(newUser.ToContract());

            return Ok(registrationResult);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            this.gameService.LeaveGame(this.HttpContext.GetUserId().Value);

            return Ok();
        }
    }
}