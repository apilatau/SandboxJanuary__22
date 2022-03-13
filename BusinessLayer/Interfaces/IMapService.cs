using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IMapService
    {
        Task<List<Map>> GetAllMaps(int id = default);
        Task<int> DeleteMap(int id);
        Task<int> AddMap(Map map);
        Task<Map> GetMapById(int id);
        Task<List<Map>> GetMapsForEachOffice(List<Office> offices);        
    }
}

// Task<ResponseBase<MapResponseDto>> AddMap(CreateMapDto mapDto);
//  Task<List<MapResponseDto>> GetMapsForEachOffice(List<OfficeResponseDto> offices, CancellationToken cancellationToken = default);