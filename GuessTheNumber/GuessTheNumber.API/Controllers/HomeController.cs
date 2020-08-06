namespace GuessTheNumber.API.Controllers
{
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.BLL.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAuthManager authManager;

        private readonly IUserService userService;

        public HomeController(IAuthManager authenticationManager, IUserService userService)
        {
            this.authManager = authenticationManager;
            this.userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserContract creds)
        {
            var loginedUser = this.userService.Login(creds);

            if (!loginedUser)
            {
                return Unauthorized();
            }

            var token = this.authManager.Authenticate(creds.Email);

            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] NewUserContract newUser)
        {
            var registeredUser = this.userService.Register(newUser);

            if (registeredUser == null)
            {
                return Conflict();
            }

            var token = this.authManager.Authenticate(registeredUser.Email);

            return Ok(new { token, registeredUser });
        }
    }
}