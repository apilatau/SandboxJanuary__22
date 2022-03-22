﻿using BusinessLayer;
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

            

            var cities = await _cityService.GetAllCities();
            //{
            //    "moscow", "tashkent", "tbilis"
            //};

            //var button = new InlineKeyboardButton[citis.Count()][];

            //foreach(var c in citis)
            //{
            //    button[0][0] = c;
            //}
            var markup = new InlineKeyboardMarkup(
            new InlineKeyboardButton[][]
            {
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton
                        .WithCallbackData(text: "Tashkent", callbackData: "A"),

                    InlineKeyboardButton
                        .WithCallbackData(text: "bu", callbackData: "B")
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton
                        .WithCallbackData(text: "Warsaw", callbackData: "W"),
                    InlineKeyboardButton
                        .WithCallbackData(text: "Moscow", callbackData: "M")
                }
            });
            await _botClient.SendTextMessageAsync(
                chatId: update.Message!.Chat.Id,
                text: "Available cities:",
                replyMarkup: markup); ;
 
        }
        
    }
}
