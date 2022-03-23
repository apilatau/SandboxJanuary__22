
using DataLayer.Models;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface ICityService
    {
        Task<List<City>> GetAllCities( CancellationToken cancellationToken = default);
        Task<List<string>> GetAllCityNames( CancellationToken cancellationToken = default);

        Task<ResponseBase<City>> DeleteCity(int id, CancellationToken cancellationToken = default);

        Task<ResponseBase<City>> AddCity(City city);

    }
}