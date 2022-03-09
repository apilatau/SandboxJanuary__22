﻿using BusinessLayer.Interfaces;
using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Dto.MapDto;
using DataLayer.Dtos.WorkingDeskDto;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Responses;
using Mapster;
using Microsoft.EntityFrameworkCore;
using DataLayer.IRepositories;

namespace BusinessLayer
{
    public class WorkingDeskService : IWorkingDeskService
    {
        private readonly IWorkingDeskRepository _workingDeskRepository;
        private AppSettings _appSettings;

        public WorkingDeskService(IWorkingDeskRepository workingDeskRepository)
        {
            _workingDeskRepository = workingDeskRepository;
            _appSettings = new AppSettings();
        }

        public async Task<WorkingDesk> AddAsync(WorkingDesk workingDesk)
        {
            return await _workingDeskRepository.AddAsync(workingDesk);
        }

        public async Task DeleteAsync(WorkingDesk workingDesk) => await _workingDeskRepository.DeleteAsync(workingDesk);

        public async Task<WorkingDesk> GetByIdAsync(int id)
        {
            return await _workingDeskRepository.GetByIdAsync(id);
        }

        public async Task<List<WorkingDesk>> ListAsync()
        {
            return await _workingDeskRepository.ListAsync();
        }

        public async Task UpdateAsync(WorkingDesk workingDesk) => await _workingDeskRepository.UpdateAsync(workingDesk);

        //private readonly WorkingDeskRepository WorkingDeskRepository;
        //private readonly ApplicationDbContext _dbContext;
        //internal DbSet<WorkingDesk> dbSet;

        //public WorkingDeskService(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //    dbSet = _dbContext.Set<WorkingDesk>();
        //}

        //public async Task<ResponseBase<WorkingDeskResponseDto>> AddWorkingDesk(CreateWorkingDeskDto workingDeskDto)
        //{
        //    var workingDeskResponse = new ResponseBase<WorkingDeskResponseDto>();
        //    var map = await _dbContext.WorkingDesks.FirstOrDefaultAsync(u => u.Id == workingDeskDto.MapId);
        //    if (map == null) throw new MapCustomException("Map not found");

        //    WorkingDesk newWorkingDesk = workingDeskDto.Adapt<WorkingDesk>();
        //    await WorkingDeskRepository.AddAsync(newWorkingDesk);
        //    var workingDeskResponseDto = newWorkingDesk.Adapt<WorkingDeskResponseDto>(); // Mapster
        //    workingDeskResponse.Data = workingDeskResponseDto;

        //    return workingDeskResponse;
        //}
        //public Task<ResponseBase<CreateWorkingDeskDto>> DeleteWorkingDesk(int id, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<List<WorkingDeskResponseDto>> GetAllWorkingDesks(int id, CancellationToken cancellationToken = default)
        //{
        //    List<WorkingDeskResponseDto> workingDesks = await dbSet
        //        .Select(m => m.Adapt<WorkingDeskResponseDto>())
        //        .Where(m => m.MapId == id)
        //        .ToListAsync(cancellationToken);
        //    return workingDesks;
        //}

        //public Task<ResponseBase<CreateWorkingDeskDto>> GetWorkingDeskById(int id, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<List<WorkingDeskResponseDto>> GetWorkingDesksForEachMap(List<MapResponseDto> maps, CancellationToken cancellationToken = default)
        //{
        //    var workingDeskResponseDtosList = new List<WorkingDeskResponseDto>();
        //    foreach (var map in maps)
        //    {
        //        var workingDesks = await dbSet
        //            .Select(m => m.Adapt<WorkingDeskResponseDto>())
        //            .Where(m => m.MapId == map.MapId)
        //            .ToListAsync(cancellationToken);
        //        workingDeskResponseDtosList.AddRange(workingDesks);
        //    };
        //    return workingDeskResponseDtosList;
        //}
    }
}