namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.BLL.Interfaces;
    using GuessTheNumber.Web.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService historyService;

        public HistoryController(IHistoryService historyService)
        {
            this.historyService = historyService;
        }

        [HttpGet("{page}")]
        public IActionResult Get(int page, [FromBody] int gamesPerPage)
        {
            var gameList = this.historyService.GetGameHistory(page, gamesPerPage, this.HttpContext.GetUserId());
            return Ok(gameList);
        }
    }
}