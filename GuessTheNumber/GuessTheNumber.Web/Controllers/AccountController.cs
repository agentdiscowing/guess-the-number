namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Contracts;
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
        public IActionResult Login([FromBody] LoginUserContract creds)
        {
            string token = this.authService.Login(creds);

            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] NewUserContract newUser)
        {
            string token = this.authService.Register(newUser);

            return Ok(token);
        }
    }
}