using DataLayer.Dto.MapDto;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface IMapService
    {
        Task<List<MapResponseDto>> GetAllMaps(CancellationToken cancellationToken = default);

        Task<ResponseBase<CreateMapDto>> DeleteMap(int id, CancellationToken cancellationToken = default);

        Task<ResponseBase<MapResponseDto>> AddMap(CreateMapDto mapDto);
        Task<ResponseBase<CreateMapDto>> GetMapById(int id, CancellationToken cancellationToken = default);
    }
}
