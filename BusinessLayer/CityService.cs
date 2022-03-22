using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Responses;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class CityService : ICityService  
    {
        private readonly ICityRepository _cityRepository;
    

        public CityService( ICityRepository cityRepository)
        {
 
            _cityRepository = cityRepository;
        }

        public Task<ResponseBase<City>> AddCity(City cityDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBase<City>> DeleteCity(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<City>> GetAllCities(CancellationToken cancellationToken = default)
        {
            return await _cityRepository.ListAsync();
        }




        //public async Task<ResponseBase<CityResponseDto>> AddCity(CreateCityDto cityDto)
        //{
        //    var cityResponse = new ResponseBase<CityResponseDto>();
        //    //var country = await dbContext.Cities.FirstOrDefaultAsync(u => u.Id == cityDto.CountryId);
        //    //if (country == null) throw new CountryCustomException("Office not found");

        //    City newCity = cityDto.Adapt<City>();
        //    await _cityRepository.AddAsync(newCity);
        //    var cityResponseDto = newCity.Adapt<CityResponseDto>(); // Mapster
        //    cityResponse.Data = cityResponseDto;

        //    return cityResponse;
        //}
        //public Task<ResponseBase<CreateCityDto>> DeleteCity(int id, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<List<City>> GetAllCities(CancellationToken cancellationToken = default)
        //{
        //    //List<CityResponseDto> cities = await dbSet
        //    //    .Select(m => m.Adapt<CityResponseDto>())
        //    //    // .Where(m => m.CountryId == id)
        //    //    .ToListAsync(cancellationToken);

        //    var cities = await  _cityRepository.ListAsync(cancellationToken);
        //    return cities;
        //}

        //public async Task<List<CityResponseDto>> GetCitiesAsync()
        //{
        //    var cities = await dbSet.Select(m => m.Adapt<CityResponseDto>()).ToListAsync();
        //    return cities;
        //}

    }
}