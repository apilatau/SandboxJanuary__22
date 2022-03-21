using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotAPI.States
{
    public class SelectStartDate : IBookingState
    {
        private readonly ITelegramBotClient _botClient;

        public bool IsFinished { get; set; }
        public SelectStartDate(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }
        public async Task ExecuteAsync(Update update)
        {
            await _botClient.SendTextMessageAsync(
                chatId: update.CallbackQuery!.Message!.Chat.Id,
                text: "Available dates");
        
        }

    }
}
