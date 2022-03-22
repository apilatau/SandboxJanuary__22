using DataLayer.Dto.MapDto;
using DataLayer.Dtos.OfficeDto;
using DataLayer.Models;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface IMapService
    {
        //Task<List<MapResponseDto>> GetAllMaps(int id = default, CancellationToken cancellationToken = default);

        //Task<ResponseBase<CreateMapDto>> DeleteMap(int id, CancellationToken cancellationToken = default);

        //Task<ResponseBase<MapResponseDto>> AddMap(CreateMapDto mapDto);

        //Task<ResponseBase<CreateMapDto>> GetMapById(int id, CancellationToken cancellationToken = default);

        //Task<List<MapResponseDto>> GetMapsForEachOffice(List<OfficeResponseDto> offices, CancellationToken cancellationToken = default);

        Task<Map> AddAsync(Map map);
        Task DeleteAsync(Map map);
        Task<List<Map>> ListAsync();
        Task<Map> GetByIdAsync(int id);
        Task UpdateAsync(Map map);
    }
}