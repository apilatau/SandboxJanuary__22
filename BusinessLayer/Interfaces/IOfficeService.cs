using DataLayer.Dtos.CityDto;
using DataLayer.Dtos.OfficeDto;
using DataLayer.Models;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface IOfficeService
    {
        Task<List<Office>> GetAllOfficesInCity(int cityId);

        Task<int> DeleteOffice(int id);

        Task<int> AddOffice(Office office);

        Task<Office> GetOfficeById(int id);     
    }
}


//   Task<ResponseBase<OfficeResponseDto>> AddOffice(CreateOfficeDto mapDto);
//   Task<List<OfficeResponseDto>> GetOfficesForEachCity(List<CityResponseDto> cities, CancellationToken cancellationToken = default);