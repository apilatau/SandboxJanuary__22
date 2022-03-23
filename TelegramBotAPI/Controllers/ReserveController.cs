using BusinessLayer;
using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using Hangfire;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        private readonly IReserveService reserveService;
        private readonly ILogger<ReserveController> logger;

        public ReserveController(
            IReserveService reserveService,
            ILogger<ReserveController> logger)
        {
            this.reserveService = reserveService;
            this.logger = logger;
        }

        [HttpPost("BookByParameters")]
        public async Task<Reserve> BookByParameters(int userId, int workingDeskId, DateTime startDate, DateTime endDate, DayOfWeek[] selectedDays, int frequency)
        {
            return await reserveService.BookByParameters(userId, workingDeskId, startDate, endDate, selectedDays, frequency);
        }

        [HttpDelete("CancelReserve")]
        [Authorize(Roles = "Administrator")]
        public async Task CancelReserve(int reserveId)
        {
                await reserveService.DeleteAsync(reserveId);
        }

        [HttpDelete("CancelOwnReserve")]
        public async Task CancelOwnReserve(int reserveId,int telegramId)
        {
            var ownReserve = await reserveService.GetByIdAsync(reserveId);
            if (ownReserve.UserId == telegramId)
            {
                await reserveService.DeleteAsync(ownReserve.Id);
            }
        }


        [HttpDelete("TimeChecker")]
        public async void TimeChecker()
        {
            RecurringJob.AddOrUpdate(() => reserveService.TimeChecker(GetAll().Result), "1 * * * * *");
        }



        //[HttpPost("AddBooking")]
        //public async Task<Reserve> AddReserve([FromBody]Reserve reserve)
        //{
        //    return await reserveService.AddAsync(reserve);
        //}

        //[HttpPost("AddBookingInAdvance")]
        //public async Task<Reserve> AddReserveInAdvance(Reserve reserve)
        //{
        //    return await reserveService.AddInAdvanceAsync(reserve);
        //}

        [HttpGet("booking/{id}")]
        public async Task<Reserve> GetById(int id)
        {
            return await reserveService.GetByIdAsync(id);
        }

        [HttpGet("GetAll")]
        public async Task<List<Reserve>> GetAll()
        {
            return await reserveService.ListAsync();
        }

    }
}
