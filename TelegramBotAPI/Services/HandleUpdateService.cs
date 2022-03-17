using BusinessLayer;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotAPI.Commands;
using TelegramBotAPI.Controllers;

namespace TelegramBotAPI.Services
{
    public class HandleUpdateService
    {
        private readonly ILogger<HandleUpdateService> _logger;
        private readonly ITelegramBotClient _botClient;
        private readonly List<BaseCommand> _commands;
        private BaseCommand _lastCommand;

        public HandleUpdateService(
            ILogger<HandleUpdateService> logger,
            ITelegramBotClient botClient,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _botClient = botClient;
            _commands = serviceProvider.GetServices<BaseCommand>().ToList();
        }

        public async Task Execute(Update update)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageReceived(update),
                _ => UnknownUpdateHandlerAsync(update)
            };

            try
            {
                await handler;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private async Task BotOnMessageReceived(Update update)
        {
            if (update.Message.Type != MessageType.Text)
                return;

            //await _botClient.SendTextMessageAsync(
            //    chatId: update.Message.Chat.Id,
            //    text: "yoloy yo"
            //    );

            
           switch (update.Message?.Text)
           {
                case "Start Booking":
                     await ExecuteCommand(CommandNames.StartCommand, update);
                    //await _botClient.SendTextMessageAsync(
                    //                    chatId: update.Message.Chat.Id,
                    //                    text: "in start booking"
                    //                    );
                    return;
                case "Cancel or Change booking":
                    await ExecuteCommand(CommandNames.ChangeCommand, update);
                    //await _botClient.SendTextMessageAsync(
                    //                    chatId: update.Message.Chat.Id,
                    //                    text: "in chnage booking"
                    //                    );
                    return;
                    
           }

            if (update.Message != null && update.Message.Text.Contains(CommandNames.StartCommand))
            {
                await ExecuteCommand(CommandNames.StartCommand, update);
                return;
            }

        }


        private Task UnknownUpdateHandlerAsync(Update update)
        {
            return Task.CompletedTask;
        }

        private async Task ExecuteCommand(string commandName, Update update)
        {
            _lastCommand = _commands.First(x => x.Name == commandName);
            await _lastCommand.ExecuteAsync(update);


        }
    }
}
