using DataLayer.Dto.MapDto;
using DataLayer.Responses;

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
