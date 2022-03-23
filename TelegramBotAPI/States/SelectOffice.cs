using BusinessLayer.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotAPI.States
{
    public class SelectOffice : IBookingState
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IStateService _stateService;
        public SelectOffice(ITelegramBotClient botClient, IStateService stateService)
        {
            _botClient = botClient;
            _stateService = stateService;
        }


        public async Task ExecuteAsync(Update update)
        {
            var state = (await _stateService.CurrentListOfStates()).LastOrDefault();
            state!.level = 2;
            var markup = new InlineKeyboardMarkup(
            new InlineKeyboardButton[][]
            {

                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton
                        .WithCallbackData(text: "Office 1", callbackData: "Office 1"),

                    InlineKeyboardButton
                        .WithCallbackData(text: "Office 2", callbackData: "Office 2")
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton
                        .WithCallbackData(text: "Office 3", callbackData: "Office 3"),
                    InlineKeyboardButton
                        .WithCallbackData(text: "Office 4", callbackData: "Office 4")
                }
            });

            await _botClient.SendTextMessageAsync(
                   chatId: update.CallbackQuery.Message!.Chat.Id,
                   text: "Available Offices:",
                   replyMarkup: markup);
        }

        
    }
}
