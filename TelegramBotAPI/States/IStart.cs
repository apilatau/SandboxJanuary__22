using Telegram.Bot.Types;

namespace TelegramBotAPI.States
{
    public interface IStart
    {
        Task Menu(Update update);
    }
}
