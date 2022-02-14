using Telegram.Bot;

namespace BookBot.Services
{
    public class HandleUpdateService
    {
        private readonly ILogger<HandleUpdateService> _logger;
        private readonly ITelegramBotClient _botClient;

        public HandleUpdateService(ILogger<HandleUpdateService> logger, ITelegramBotClient botClient)
        {
            _logger = logger;
            _botClient = botClient;
        }
    }
}
