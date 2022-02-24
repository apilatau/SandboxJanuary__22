using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

    }
}
