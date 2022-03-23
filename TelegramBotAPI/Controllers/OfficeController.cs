using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService officeService;
        private readonly ILogger<OfficeController> logger;

        public OfficeController(IOfficeService officeService,
            ILogger<OfficeController> logger)
        {
            this.officeService = officeService;
            this.logger = logger;
        }

        [HttpGet("SearchSpecificOfficePlan")]
        public async Task<List<Office>> SearchSpecificOfficePlan(string? name, string? address, int? cityId, int? countryId)
        {
            return await officeService.SearchSpecificOfficePlan(name, address, cityId, countryId);
        }

        [HttpPost]
        [Authorize(Roles = "Map Editor")]
        public async Task<Office> AddOffice(Office office)
        {
            return await officeService.AddAsync(office);
        }

        [HttpPut]
        [Authorize(Roles = "Map Editor")]
        public async Task UpdateOffice(Office office) => await officeService.UpdateAsync(office);

        [HttpDelete]
        [Authorize(Roles = "Map Editor")]
        public async Task DeleteOffice(Office office) => await officeService.DeleteAsync(office);

        [HttpGet("getall")]
        public async Task<List<Office>> ListAsync()
        {
            return await officeService.ListAsync();
        }
    }
}
