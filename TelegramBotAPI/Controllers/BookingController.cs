using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Booking(int userID, int seatID, DateTime startDate, DateTime endDate)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Booking(int userID, int seatID, DayOfWeek[] days, ushort frequency, DateTime startDate, DateTime endDate)
        {
            return Ok();
        }
    }
}
