using DataLayer.Dtos.CityDto;
using DataLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
