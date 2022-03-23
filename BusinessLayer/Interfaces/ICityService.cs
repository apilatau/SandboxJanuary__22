using DataLayer.Dtos.CityDto;
using DataLayer.Models;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface ICityService
    {
        Task<List<City>> GetAllCities(int id = default);

        Task<int> DeleteCity(int id);

        Task<int> AddCity(City city);

        Task<City> GetCityById(int id);
    }
}