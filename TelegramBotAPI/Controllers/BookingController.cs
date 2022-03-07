using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
