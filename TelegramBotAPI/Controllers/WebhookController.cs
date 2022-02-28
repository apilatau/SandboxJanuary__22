using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBotAPI.Services;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromServices] HandleUpdateService handleUpdateService,
                                             [FromBody] Update update)
        {
            await handleUpdateService.EchoAsync(update);

            return Ok();
        }
    }
}
