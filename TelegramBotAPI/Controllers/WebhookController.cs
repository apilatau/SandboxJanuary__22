using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using TelegramBotAPI.Services;

namespace TelegramBotAPI.Controllers
{
    
    public class WebhookController : ControllerBase
    {
        
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices] HandleUpdateService handleUpdateService,
            [FromBody] Update update)
        {

            await handleUpdateService.Execute(update);
            return Ok();
        }
    
    }
}
