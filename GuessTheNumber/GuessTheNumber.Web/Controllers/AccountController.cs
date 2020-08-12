namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.Web.Models.Request;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authenticationService)
        {
            this.authService = authenticationService;
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
            // will add auto mapper later
            var registrationResult = this.authService.Register(new NewUserContract
            {
                Email = newUser.Email,
                Password = newUser.Password,
                Username = newUser.Username
            });

            return Ok(registrationResult);
        }
    }
}