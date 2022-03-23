using DataLayer.IRepositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IMapRepository mapRepository;

        public MapController(IMapRepository mapRepository)
        {
            this.mapRepository = mapRepository;
        }

        [HttpPost("addMap")]
        public async Task<Map> AddRole(Map map)
        {
            return await mapRepository.AddAsync(map);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(Map map) => await mapRepository.DeleteAsync(map);

        [HttpGet("City/{id}")]
        public async Task<Map> GetByIdAsync(int id)
        {
            return await mapRepository.GetByIdAsync(id);
        }

        [HttpGet("Maps")]
        public async Task<List<Map>> ListAsync()
        {
            return await mapRepository.ListAsync();
        }

        [HttpPut("update")]
        public async Task UpdateAsync(Map map) => await mapRepository.UpdateAsync(map);
    }
}
