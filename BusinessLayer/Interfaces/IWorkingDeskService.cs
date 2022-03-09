﻿using DataLayer.Dto.MapDto;
using DataLayer.Dtos.WorkingDeskDto;
using DataLayer.Models;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface IWorkingDeskService
    {
        Task<WorkingDesk> AddAsync(WorkingDesk workingDesk);
        Task DeleteAsync(WorkingDesk workingDesk);
        Task<List<WorkingDesk>> ListAsync();
        Task<WorkingDesk> GetByIdAsync(int id);
        Task UpdateAsync(WorkingDesk workingDesk);

        //Task<List<WorkingDeskResponseDto>> GetAllWorkingDesks(int id = default, CancellationToken cancellationToken = default);

        //Task<ResponseBase<CreateWorkingDeskDto>> DeleteWorkingDesk(int id, CancellationToken cancellationToken = default);

        //Task<ResponseBase<WorkingDeskResponseDto>> AddWorkingDesk(CreateWorkingDeskDto mapDto);

        //Task<ResponseBase<CreateWorkingDeskDto>> GetWorkingDeskById(int id, CancellationToken cancellationToken = default);

        //Task<List<WorkingDeskResponseDto>> GetWorkingDesksForEachMap(List<MapResponseDto> maps, CancellationToken cancellationToken = default);
    }
}