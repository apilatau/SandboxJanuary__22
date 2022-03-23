using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly AppSettings _appSettings;

        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
            _appSettings = new AppSettings();
        }

        public async Task<Country> AddAsync(Country country)
        {
            return await countryRepository.AddAsync(country);
        }

        public async Task DeleteAsync(Country country) => await countryRepository.DeleteAsync(country);

        public async Task<Country> GetByIdAsync(int id)
        {
            return await countryRepository.GetByIdAsync(id);
        }

        public async Task<List<Country>> ListAsync()
        {
            return await countryRepository.ListAsync();
        }

        public async Task UpdateAsync(Country country) => await countryRepository.UpdateAsync(country);
    }
}
