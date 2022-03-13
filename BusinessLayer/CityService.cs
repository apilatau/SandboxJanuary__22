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
        internal DbSet<City> dbSet;

        public CityService(ApplicationDbContext dbContext, ICityRepository cityRepository)
        {
        }

        public async Task<int> AddCity(City city)
        {
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