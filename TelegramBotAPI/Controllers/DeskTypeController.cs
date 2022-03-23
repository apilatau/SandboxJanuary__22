using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskTypeController : ControllerBase
    {
        private readonly IDeskTypeService _deskTypeService;

        public DeskTypeController(IDeskTypeService deskTypeService)
        {
            _deskTypeService = deskTypeService;
        }

        [HttpPost("adddesktype")]
        public async Task<DeskType> AddDeskType(DeskType deskType)
        {
            return await _deskTypeService.AddAsync(deskType);
        }
        [HttpDelete("delete")]
        public async Task DeleteType(DeskType deskType) => await _deskTypeService.DeleteAsync(deskType);

        [HttpGet("GetAllDeskType")]
        public async Task<List<DeskType>> ListAsync()
        {
            return await _deskTypeService.ListAsync();
        }
    }
}
