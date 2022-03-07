namespace BusinessLayer.Interfaces
using DataLayer.Dto.MapDto;
using DataLayer.Dtos.WorkingDeskDto;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface IWorkingDeskService
    {
        Task<List<WorkingDeskResponseDto>> GetAllWorkingDesks(int id = default, CancellationToken cancellationToken = default);

        Task<ResponseBase<CreateWorkingDeskDto>> DeleteWorkingDesk(int id, CancellationToken cancellationToken = default);

        Task<ResponseBase<WorkingDeskResponseDto>> AddWorkingDesk(CreateWorkingDeskDto mapDto);

        Task<ResponseBase<CreateWorkingDeskDto>> GetWorkingDeskById(int id, CancellationToken cancellationToken = default);

        Task<List<WorkingDeskResponseDto>> GetWorkingDesksForEachMap(List<MapResponseDto> maps, CancellationToken cancellationToken = default);
    }
}