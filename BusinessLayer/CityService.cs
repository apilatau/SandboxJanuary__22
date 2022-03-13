using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<City> dbSet;

        public CityService(ApplicationDbContext dbContext, ICityRepository cityRepository)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<City>();
            _cityRepository = cityRepository;
        }

        public async Task<int> AddCity(City city)
        {
            var country = await _dbContext.Cities.FirstOrDefaultAsync(u => u.Id == city.Id);
            if (country == null) throw new CountryCustomException("Country not found");
            await _cityRepository.AddAsync(city);

            return city.Id;
        }
        public async Task<int> DeleteCity(int id)
        {
            var city = await _dbContext.Cities.FirstOrDefaultAsync(x => x.Id == id);
            if (city != null)
            {
                await _cityRepository.DeleteAsync(city);
            }
            await _cityRepository.SaveChangesAsync();

            return id;
        }

        public async Task<List<City>> GetAllCities(int id)
        {
            List<City> cities = await dbSet
                .Select(m => m)
                .Where(m => m.Id == id)
                .ToListAsync();
            return cities;
        }

        public async Task<City> GetCityById(int id)
        {
            var city = await _dbContext.Cities.FirstOrDefaultAsync(x => x.Id == id);
            return city;
        }
    }
}