using DataLayer.Dtos.CityDto;
using DataLayer.Dtos.OfficeDto;
using DataLayer.Models;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface IOfficeService
    {
        public Task<List<Office>> SearchSpecificOfficePlan(string? name, string? address, int? cityId, int? countryId);
        Task<List<OfficeResponseDto>> GetAllOffices(int id = default, CancellationToken cancellationToken = default);

        Task<ResponseBase<OfficeResponseDto>> DeleteOffice(int id, CancellationToken cancellationToken = default);

        Task<ResponseBase<OfficeResponseDto>> AddOffice(CreateOfficeDto mapDto);

        Task<ResponseBase<OfficeResponseDto>> GetOfficeById(int id, CancellationToken cancellationToken = default);

        Task<List<OfficeResponseDto>> GetOfficesForEachCity(List<CityResponseDto> cities, CancellationToken cancellationToken = default);
    }
}