using BusinessLayer;
using BusinessLayer.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotAPI.Controllers;
using TelegramBotAPI.States;

namespace TelegramBotAPI.Services
{
    public class HandleUpdateService
    {
        private readonly ILogger<HandleUpdateService> _logger;
        private readonly ITelegramBotClient _botClient;
        private readonly IStart _start;
        public IBookingState bookingState { get; set; }

        public HandleUpdateService(
            ILogger<HandleUpdateService> logger,
            ITelegramBotClient botClient,
            IStart start,
            IServiceProvider serviceProvider, 
            ICityService cityService)
        {
            _logger = logger;
            _botClient = botClient;
            _start = start;

            bookingState = new SelectCity(_botClient, cityService);
        }

        public async Task Execute(Update update)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageReceived(update),
                UpdateType.CallbackQuery => BotOnCallbackQueryReceived(update),
                _ => UnknownUpdateHandlerAsync(update)
            };

            try
            {
                await handler;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private async Task BotOnCallbackQueryReceived(Update update)
        {
            if (CheckCity(update.CallbackQuery?.Data))
            {
                bookingState = new SelectOffice(_botClient);
                await StartBooking(update);
            }

            if (CheckOffice(update.CallbackQuery?.Data))
            {
                bookingState = new SelectStartDate(_botClient);
                await StartBooking(update);
            }
        }

        private bool CheckOffice(string? data)
        {
            if (data == "Office1")
            {
                return true;
            }
            return false;
        }

        private bool CheckCity(string? data)
        {
            if(data == "A")
            {
                return true;
            }
            return false;
        }

        private async Task BotOnMessageReceived(Update update)
        {
            if (update.Message.Type != MessageType.Text)
                return;

            
            //bookingState.IsFinished = true;
          
            switch (update.Message?.Text)
            {
                case "/start":
                    await _start.Menu(update);
                    return;
                case "Start Booking":
                    await StartBooking(update);                     
                    return;

            };
            
            
        }


        private async Task StartBooking(Update update)
        {
            
            await bookingState.ExecuteAsync(update);
             
        }

        private Task UnknownUpdateHandlerAsync(Update update)
        {
            return Task.CompletedTask;
        }

    }
}
