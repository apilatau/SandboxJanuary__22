using BusinessLayer;
using BusinessLayer.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotAPI.Commands
{
    public class ChangeCommand : BaseCommand
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IReserveService _reserveService;

        public ChangeCommand(ITelegramBotClient botClient, IReserveService reserveService)
        {
            _botClient = botClient;
            _reserveService = reserveService;
        }
        public override string Name => CommandNames.ChangeCommand;

        public async override Task ExecuteAsync(Update update)
        {
            
            var bookings = _reserveService.TestBot();

           await _botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text:  bookings);
        }
    }
}
