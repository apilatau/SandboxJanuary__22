using BookBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace BookBot.Services
{
    public class ConfigureWebHook : IHostedService
    {
        private readonly ILogger<ConfigureWebHook> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly BotConfiguration _botConfig;

        public ConfigureWebHook(ILogger<ConfigureWebHook> logger,
            IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _botConfig = configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            
            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();
            
            var webhookAddress = $@"{_botConfig.HostAddress}/bot/{_botConfig.Token}"; // webhook address
            
            _logger.LogInformation("Setting webhook");
            
            await botClient.SendTextMessageAsync(chatId: 718428065, text: "WebHook is being instlled");
            
            await botClient.SetWebhookAsync(
                url: webhookAddress,
                allowedUpdates: Array.Empty<UpdateType>(),
                cancellationToken: cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            
            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();
     
            _logger.LogInformation("WebHook Removed");
            
            await botClient.SendTextMessageAsync(chatId: 718428065, text: "Bot is sleeping");
        }
    }
}
