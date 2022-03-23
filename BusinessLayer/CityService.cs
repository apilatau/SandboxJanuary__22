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
    public class CityService : ICityService
    {
        private readonly AppSettings _appSettings;
        private readonly ICityRepository cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _appSettings = new AppSettings();
            cityRepository = cityRepository;
        }
        public async Task<City> AddAsync(City city)
        {
            return await cityRepository.AddAsync(city);
        }

        public async Task DeleteAsync(City city) => await cityRepository.DeleteAsync(city);

        public async Task<City> GetByIdAsync(int id)
        {
            return await cityRepository.GetByIdAsync(id);
        }

        public  async Task<List<City>> ListAsync()
        {
            return await cityRepository.ListAsync();
        }

        public async Task UpdateAsync(City city) => await cityRepository.UpdateAsync(city);
    }
}
