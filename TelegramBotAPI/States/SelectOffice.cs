using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotAPI.States
{
    public class SelectOffice : IBookingState
    {
        private readonly ITelegramBotClient _botClient;

        public SelectOffice(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public bool IsFinished { get; set; }

        public async Task ExecuteAsync(Update update)
        {
            var markup = new InlineKeyboardMarkup(
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton
                        .WithCallbackData(text: "Office1", callbackData: "Office1"),

                    InlineKeyboardButton
                        .WithCallbackData(text: "Office2", callbackData: "Office2")
                });
            
            await _botClient.SendTextMessageAsync(
                   chatId: update.CallbackQuery!.Message!.Chat.Id,
                   text: "Available Offices:",
                   replyMarkup: markup);
        }

        
    }
}
