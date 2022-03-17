using Telegram.Bot.Types;

namespace TelegramBotAPI.Services
{
    public interface ICommandExecuter
    {
        Task Execute(Update update);
    }
}
