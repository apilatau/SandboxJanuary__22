using Telegram.Bot.Types;

namespace TelegramBotAPI.States
{
    public interface IBookingState
    {
        Task ExecuteAsync(Update update);
        public bool IsFinished { get; set; } 
    }
}
