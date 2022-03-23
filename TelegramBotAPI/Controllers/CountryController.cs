using DataLayer.IRepositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }


        [HttpPost("addCountry")]
        public async Task<Country> AddRole(Country country)
        {
            return await countryRepository.AddAsync(country);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(Country country) => await countryRepository.DeleteAsync(country);

        [HttpGet("Country/{id}")]
        public async Task<Country> GetByIdAsync(int id)
        {
            return await countryRepository.GetByIdAsync(id);
        }

        [HttpGet("Countries")]
        public async Task<List<Country>> ListAsync()
        {
            return await countryRepository.ListAsync();
        }

        [HttpPut("update")]
        public async Task UpdateAsync(Country country) => await countryRepository.UpdateAsync(country);

    }
}
