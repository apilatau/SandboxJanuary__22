using BusinessLayer;
using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;


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

        [HttpPost("AddBooking")]
        public async Task<Reserve> AddReserve(Reserve reserve)
        {
            return await reserveService.AddAsync(reserve);
        }


        [HttpGet("ClaimAllRunningReserve")]
        public async Task<List<Reserve>> RunningReserves()
        {
            return await reserveService.ListAsync();
        }

    }
}
