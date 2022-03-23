using DataLayer.IRepositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeRepository officeRepository;

        public OfficeController(IOfficeRepository officeRepository)
        {
            this.officeRepository = officeRepository;
        }


        [HttpPost("addOffice")]
        public async Task<Office> AddRole(Office office)
        {
            return await officeRepository.AddAsync(office);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(Office office) => await officeRepository.DeleteAsync(office);

        [HttpGet("Office/{id}")]
        public async Task<Office> GetByIdAsync(int id)
        {
            return await officeRepository.GetByIdAsync(id);
        }

        [HttpGet("Offices")]
        public async Task<List<Office>> ListAsync()
        {
            return await officeRepository.ListAsync();
        }

        [HttpPut("update")]
        public async Task UpdateAsync(Office office) => await officeRepository.UpdateAsync(office);
    }
}
