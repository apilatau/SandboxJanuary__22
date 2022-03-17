using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotAPI.Services;

namespace TelegramBotAPI.Commands
{
    public class StartCommand : BaseCommand
    {
        private readonly ITelegramBotClient _botClient;

        public StartCommand(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }
        public override string Name => CommandNames.StartCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var inlineKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new[]
                {
                    new KeyboardButton("Start Booking"),
                    new KeyboardButton("Cancel or Change booking")
                }
                
            });

            inlineKeyboard.ResizeKeyboard = true;

            await _botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                "Welcome to booking bot!",
                ParseMode.Markdown, 
                replyMarkup: inlineKeyboard);
        }
    }
}
