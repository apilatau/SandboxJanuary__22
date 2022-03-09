using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotAPI.Services
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

        public async Task EchoAsync(Update update)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageReceived(update.Message),
                UpdateType.CallbackQuery => BotOnCallBackQueryReceived(update.CallbackQuery),
                _ => UnknownUpdateHandler(update)
            };

            try
            {
                await handler;
            }
            catch (Exception ex)
            {
                await HandlerErrorAsync(ex);
            }
        }

        public Task HandlerErrorAsync(Exception ex)
        {
            var ErrorMessage = ex switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n{apiRequestException.ErrorCode}",
                _ => ex.ToString()
            };

            _logger.LogInformation(ErrorMessage);

            return Task.CompletedTask;
        }

        private Task UnknownUpdateHandler(Update update)
        {
            _logger.LogInformation($"Unknown update type : {update}");

            return Task.CompletedTask;
        }

        private async Task BotOnCallBackQueryReceived(CallbackQuery? callbackQuery)
        {
            await _botClient.SendTextMessageAsync(
                chatId: callbackQuery.Message.Chat.Id,
                text: $"{callbackQuery.Data}");
        }

        private async Task BotOnMessageReceived(Message? message)
        {
            _logger.LogInformation($"Xabar keldi: {message.Type}");

            await _botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Botga xabar keldi");
        }
    }
}
