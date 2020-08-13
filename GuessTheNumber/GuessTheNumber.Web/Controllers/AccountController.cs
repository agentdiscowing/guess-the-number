﻿namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using GuessTheNumber.Web.Extensions.ConvertingExtensions;
    using GuessTheNumber.Web.Models.Request;
    using GuessTheNumber.Web.Models.Response;
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
        public IActionResult Logout()
        {
            this.gameService.LeaveGame(this.HttpContext.GetUserId(), this.HttpContext.GetCurrentGameId());

            return Ok();
        }
    }
}