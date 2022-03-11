using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Dtos.CityDto;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Responses;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class CityService : ICityService
    {
        private readonly CityRepository cityRepository;
        private readonly ApplicationDbContext dbContext;
        internal DbSet<City> dbSet;

        public CityService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<City>();
        }

        public async Task<ResponseBase<CityResponseDto>> AddCity(CreateCityDto cityDto)
        {
            var cityResponse = new ResponseBase<CityResponseDto>();
            var country = await dbContext.Cities.FirstOrDefaultAsync(u => u.Id == cityDto.CountryId);
            if (country == null) throw new CountryCustomException("Office not found");

            City newCity = cityDto.Adapt<City>();
            await cityRepository.AddAsync(newCity);
            var cityResponseDto = newCity.Adapt<CityResponseDto>(); // Mapster
            cityResponse.Data = cityResponseDto;

            return cityResponse;
        }
        public Task<ResponseBase<CreateCityDto>> DeleteCity(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CityResponseDto>> GetAllCities(int id, CancellationToken cancellationToken = default)
        {
            List<CityResponseDto> cities = await dbSet
                .Select(m => m.Adapt<CityResponseDto>())
                .Where(m => m.CountryId == id)
                .ToListAsync(cancellationToken);
            return cities;
        }

        public Task<ResponseBase<CreateCityDto>> GetCityById(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}