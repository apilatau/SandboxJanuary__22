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
        public IBookingState bookingState { get; set; }
        private readonly ICityService _cityService;


        public SelectCity(ITelegramBotClient botClient, ICityService cityService)
        {
            _botClient = botClient;
            _cityService = cityService;

        }
       
        public async Task ExecuteAsync(Update update)
        {

            var cities = await _cityService.GetAllCityNames();

            List<InlineKeyboardButton> buttons = new List<InlineKeyboardButton>();
            for (int i = 0; i < cities.Count(); i++)
            {
                buttons.Add(new InlineKeyboardButton(cities[i + 1]).ToString()!);
            }

            var twoMenu = new List<InlineKeyboardButton[]>();
            for (var i = 0; i < buttons.Count; i++)
            {
                if (buttons.Count - 1 == i)
                {
                    twoMenu.Add(new[] { buttons[i] });
                }
                else
                    twoMenu.Add(new[] { buttons[i], buttons[i + 1] });
                i++;
            }

            var markup = new InlineKeyboardMarkup(twoMenu.ToArray());

            //var markup = new InlineKeyboardMarkup(
            //new InlineKeyboardButton[][]
            //{

            //    new InlineKeyboardButton[]
            //    {
            //        InlineKeyboardButton
            //            .WithCallbackData(text: "Tashkent", callbackData: "A"),

            //        InlineKeyboardButton
            //            .WithCallbackData(text: "bu", callbackData: "B")
            //    },
            //    new InlineKeyboardButton[]
            //    {
            //        InlineKeyboardButton
            //            .WithCallbackData(text: "Warsaw", callbackData: "W"),
            //        InlineKeyboardButton
            //            .WithCallbackData(text: "Moscow", callbackData: "M")
            //    }
            //});
            await _botClient.SendTextMessageAsync(
                chatId: update.Message!.Chat.Id,
                text: "Available cities:",
                replyMarkup: markup); ;
 
        }
        
    }
}
