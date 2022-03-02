using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotAPI.Services
{
    public class HandleUpdateService
    {
        private readonly ILogger<HandleUpdateService> _logger;
        private readonly ITelegramBotClient _botClient;

        public HandleUpdateService(ILogger<HandleUpdateService> logger, ITelegramBotClient botCLient)
        {
            _logger = logger;
            _botClient = botCLient;
        }

        public async Task EchoAsync(Update update)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageRecieved(update.Message!),
                UpdateType.CallbackQuery => BotOnCallBackQueryRecieved(update.CallbackQuery!),
                _ => UnknownUpdateTypeHandler(update)
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

        private async Task BotOnMessageRecieved(Message message)
        {
            _logger.LogInformation($"Message recieved: {message.Type}");

            await _botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Bot has revieved message!"
                );
        }

        private Task HandlerErrorAsync(Exception ex)
        {
            var ErrorMessage = ex switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => ex.ToString()
            };

            _logger.LogInformation("HandleError: {ErrorMessage}", ErrorMessage);
            return Task.CompletedTask;
        }

        private Task UnknownUpdateTypeHandler(Update update)
        {
            _logger.LogInformation($"Unknown update type: {update.Type}");

            return Task.CompletedTask;
        }

        private async Task BotOnCallBackQueryRecieved(CallbackQuery callbackQuery)
        {
            await _botClient.SendTextMessageAsync(
                chatId:  callbackQuery.Message.Chat.Id,
                text: $"{callbackQuery.Data}"
                );
        }

        
    }
}
