using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TelegramBotAPI.Services
{
    public class ConfigureWebHook : IHostedService
    {
        private readonly ILogger<ConfigureWebHook> _logger;   
        private readonly IServiceProvider _serviceProvider;
        private readonly BotConfiguration _botConfig;

        public ConfigureWebHook(ILogger<ConfigureWebHook> logger,
            IServiceProvider serviceProvider, 
            IConfiguration configuration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _botConfig = configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

            var webhookAddress = $@"{_botConfig.HostAddress}/bot/{_botConfig.Token}";

            _logger.LogInformation("Setting webhook");

            await botClient.SendTextMessageAsync(
                chatId: 1678231744,
                text: "Bot has started working!");

            await botClient.SetWebhookAsync(
                url: webhookAddress,
                allowedUpdates: Array.Empty<UpdateType>(),
                cancellationToken : cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();
            
            _logger.LogInformation("WebHook removing");

            await botClient.SendTextMessageAsync(
                chatId: 1678231744,
                text: "Bot is sleeping");
        }
    }
}
