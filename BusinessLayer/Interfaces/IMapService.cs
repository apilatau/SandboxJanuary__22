using DataLayer.Dto;
using DataLayer.Dto.MapDto;
using DataLayer.Models;
using DataLayer.Responses;
using System.Linq.Expressions;

namespace BusinessLayer.Interfaces
{
    public interface IMapService
    {
        // DONE
        Task<List<MapResponseDto>> GetAllMaps(CancellationToken cancellationToken = default);

        Task<MapResponse<CreateMapDto>> DeleteMap(int id, CancellationToken cancellationToken = default);
        
        //DOING
        Task<MapResponse<MapResponseDto>> AddMap(CreateMapDto mapDto);
        Task<MapResponse<CreateMapDto>> GetMapById(int id, CancellationToken cancellationToken = default);
    }
}
