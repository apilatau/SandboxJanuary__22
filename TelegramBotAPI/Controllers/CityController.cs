using DataLayer.IRepositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        [HttpPost("addCity")]
        public async Task<City> AddRole(City city)
        {
            return await cityRepository.AddAsync(city);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(City city) => await cityRepository.DeleteAsync(city);

        [HttpGet("City/{id}")]
        public async Task<City> GetByIdAsync(int id)
        {
            return await cityRepository.GetByIdAsync(id);
        }

        [HttpGet("Cities")]
        public async Task<List<City>> ListAsync()
        {
            return await cityRepository.ListAsync();
        }

        [HttpPut("update")]
        public async Task UpdateAsync(City city) => await cityRepository.UpdateAsync(city);
    }
}
