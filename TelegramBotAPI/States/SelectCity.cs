using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotAPI.States
{
    public class SelectCity : IBookingState
    {
        private readonly ITelegramBotClient _botClient;
        public bool IsFinished { get; set; }
        public IBookingState bookingState { get; set; }
        public SelectCity(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }
        public async Task ExecuteAsync(Update update)
        {
            var markup = new InlineKeyboardMarkup(
            new InlineKeyboardButton[][]
            {
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton
                        .WithCallbackData(text: "A", callbackData: "A"),

                    InlineKeyboardButton
                        .WithCallbackData(text: "B", callbackData: "B")
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton
                        .WithCallbackData(text: "C", callbackData: "C"),
                    InlineKeyboardButton
                        .WithCallbackData(text: "D", callbackData: "D")
                }
            });
            await _botClient.SendTextMessageAsync(
                chatId: update.Message!.Chat.Id,
                text: "Available cities:",
                replyMarkup: markup); ;
 
        }

        
    }
}
