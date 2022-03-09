using DataLayer.Dtos.CityDto;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface ICityService
    {
        Task<List<CityResponseDto>> GetAllCities(int id = default, CancellationToken cancellationToken = default);

        Task<ResponseBase<CreateCityDto>> DeleteCity(int id, CancellationToken cancellationToken = default);

        Task<ResponseBase<CityResponseDto>> AddCity(CreateCityDto cityDto);

        Task<ResponseBase<CreateCityDto>> GetCityById(int id, CancellationToken cancellationToken = default);
    }
}