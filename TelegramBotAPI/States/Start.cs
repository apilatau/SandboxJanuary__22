using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotAPI.States
{
    public class Start : IStart
    {
        private readonly ITelegramBotClient _botClient;

        public Start(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task Menu(Update update)
        {
            ReplyKeyboardMarkup markup = new ReplyKeyboardMarkup("Your choice ");
            markup.Keyboard = new KeyboardButton[][] {
                new KeyboardButton[]
                {
                    new KeyboardButton("Start Booking"),

                    new KeyboardButton("Cancel or Edit Booking")
                }};
            
            markup.ResizeKeyboard = true;

            await _botClient.SendTextMessageAsync(
                chatId: update.Message?.Chat.Id,
                text: "Welcome to booking bot",
                replyMarkup: markup);
        }
    }
}
