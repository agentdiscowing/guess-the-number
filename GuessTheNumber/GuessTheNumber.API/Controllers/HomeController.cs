namespace GuessTheNumber.API.Controllers
{
    using System.Collections.Generic;
    using GuessTheNumber.BLL.Contracts;
    using GuessTheNumber.BLL.Interfaces;
    using Microsoft.AspNetCore.Authorization;
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

        // GET: api/Name
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "you are logined" };
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginUserContract creds)
        {
            var loginedUser = this.userService.Login(creds);

            if (!loginedUser)
            {
                return Unauthorized();
            }

            var token = this.authManager.Authenticate(creds.Email);

            return Ok(token);
        }
    }
}