﻿using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IWorkingDeskService
    {
        Task<int> AddAsync(WorkingDesk workingDesk);

        Task<int> DeleteAsync(int id);

        Task<List<WorkingDesk>> ListAsync();

        Task<WorkingDesk> GetByIdAsync(int id);

        Task UpdateAsync(WorkingDesk workingDesk);
        Task<List<WorkingDesk>> SearchSpecificWorkSpace(int? mapId, int? deskTypeId, int? number);

        Task<List<WorkingDesk>> GetAllWorkingDesks(int id = default);

        Task<List<WorkingDesk>> GetWorkingDesksForEachMap(List<Map> maps);

        //Task<ResponseBase<CreateWorkingDeskDto>> DeleteWorkingDesk(int id, CancellationToken cancellationToken = default);

        //Task<ResponseBase<WorkingDeskResponseDto>> AddWorkingDesk(CreateWorkingDeskDto mapDto);

        //Task<ResponseBase<CreateWorkingDeskDto>> GetWorkingDeskById(int id, CancellationToken cancellationToken = default);


    }
}