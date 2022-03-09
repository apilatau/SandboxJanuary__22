using BusinessLayer;
using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;


namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingTypeController : Controller
    {
        private readonly IBookingTypeService bookingTypeService;
        private readonly ILogger<BookingTypeController> logger;

        public BookingTypeController(IBookingTypeService bookingTypeService, ILogger<BookingTypeController> logger)
        {
            this.bookingTypeService = bookingTypeService;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<BookingType> AddBookingType(BookingType bookingType)
        {
            return await bookingTypeService.AddAsync(bookingType);
        }


        [HttpGet]
        public async Task<List<BookingType>> GetBookingTypeList()
        {
            return await bookingTypeService.ListAsync();
        }   
    }
}
