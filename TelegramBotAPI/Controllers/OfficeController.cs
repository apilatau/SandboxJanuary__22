using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : Controller
    {
        private readonly IOfficeService _officeService;
        private readonly ILogger<OfficeController> _logger;

        public OfficeController(IOfficeService officeService, ILogger<OfficeController> logger)
        {
            _officeService = officeService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<Office> AddOffice(Office office)
        {
            return await _officeService.AddAsync(office);
        }

        [HttpGet("id")]
        public async Task<Office> GetOffice(int id)
        {
            return await _officeService.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task UpdateOffice(Office office)
        {
            if (office == null) throw new ArgumentNullException(nameof(office));
            await _officeService.UpdateAsync(office);
        }

        [HttpDelete]
        public async Task DeleteOffice(Office office)
        {
            await _officeService.DeleteAsync(office);
        }
    }
}
