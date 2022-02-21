using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpGet(Name = "GetBookingTypes")]
        public string[] BookingTypes()
        {
            return new string[0];
        }
        [HttpGet(Name = "GetServiceTypes")]
        public string[] ServiceTypes()
        {
            return new string[0];
        }
        [HttpGet(Name = "BookingCheck")]
        public bool IsBooked(int reservId)
        {
            return true;
        }
        [HttpPost(Name = "BookingTime")]
        public void BookTime(DateTime startDate, DateTime endDate)
        {

        }
        [HttpPost(Name = "CancelBook")]
        public void CancelBook(int reservId)
        {

        }
        [HttpGet(Name = "CheckFreeOffices")]
        public int[] FreeOffices()
        {
            return new int[0];
        }
        [HttpGet(Name = "CheckParking")]
        public bool IsParking()
        {
            return true;
        }

    }
}
