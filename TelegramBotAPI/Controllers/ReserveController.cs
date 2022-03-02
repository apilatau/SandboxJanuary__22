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

        public ReserveController(IReserveService reserveService, ILogger<ReserveController> logger)
        {
            this.reserveService = reserveService;
            this.logger = logger;
        }


        [HttpPost]
        public async Task<Reserve> AddReserve(Reserve reserve)
        {
            return await reserveService.AddAsync(reserve);
        }

        [HttpGet]
        public async Task<Reserve> GetById(int id)
        {
            return await reserveService.GetByIdAsync(id);
        }

    }
}
