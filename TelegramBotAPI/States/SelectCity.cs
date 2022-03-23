using BusinessLayer;
using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Models;
using System.Data.Entity;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotAPI.States
{
    public class SelectCity : IBookingState
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IStateService _stateService;


        public SelectCity(ITelegramBotClient botClient, IStateService stateService)
        {
            _botClient = botClient;
            _stateService = stateService;

        }
       
        public async Task ExecuteAsync(Update update)
        {

            var state = (await _stateService.CurrentListOfStates()).LastOrDefault();
            state!.level = 1;

            var markup = new InlineKeyboardMarkup(
            new InlineKeyboardButton[][]
            {

                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton
                        .WithCallbackData(text: "Tashkent", callbackData: "Tashkent"),

                    InlineKeyboardButton
                        .WithCallbackData(text: "Tbilisi", callbackData: "Tbilisi")
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton
                        .WithCallbackData(text: "Warsaw", callbackData: "Warsaw"),
                    InlineKeyboardButton
                        .WithCallbackData(text: "Moscow", callbackData: "Moscow")
                }
            });
            
            state.cityName = update.CallbackQuery!.Data;

            await _botClient.SendTextMessageAsync(
                chatId: update.Message!.Chat.Id,
                text: "Available cities:",
                replyMarkup: markup);


        }
        
    }
}
