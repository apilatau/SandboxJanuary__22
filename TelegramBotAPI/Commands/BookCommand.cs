using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotAPI.Services;

namespace TelegramBotAPI.Commands
{
    public class BookCommand : BaseCommand
    {
        private readonly ITelegramBotClient _botClient;

        public BookCommand(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }
        public override string Name => CommandNames.BookCommand;

        public override async Task ExecuteAsync(Update update)
        {
            const string message = "Select attributes";

            await _botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id, 
                text: message, 
                ParseMode.Markdown
                );
        }
    }
}
