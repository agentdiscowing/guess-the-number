namespace GuessTheNumber.API.Controllers
{
    using System.Collections.Generic;
    using GuessTheNumber.BLL.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAuthManager authManager;

        public HomeController(IAuthManager AuthenticationManager)
        {
            this.authManager = AuthenticationManager;
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
            // validate creds

            var token = this.authManager.Authenticate(creds.Email, creds.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}