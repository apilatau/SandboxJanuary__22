using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Dto.MapDto;
using DataLayer.Dtos.WorkingDeskDto;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Responses;
using LinqKit;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class WorkingDeskService : IWorkingDeskService
    {
        private readonly IWorkingDeskRepository workingDeskRepository;
        private readonly WorkingDeskRepository WorkingDeskRepository;
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<WorkingDesk> dbSet;

        public WorkingDeskService(ApplicationDbContext dbContext, IWorkingDeskRepository workingDeskRepository)
        {
            this.workingDeskRepository = workingDeskRepository;
            _dbContext = dbContext;
            dbSet = _dbContext.Set<WorkingDesk>();
        }

        public async Task<List<WorkingDesk>> SearchSpecificWorkSpace(int? mapId, int? deskTypeId, int? number)
        {
            var predicate = PredicateBuilder.New<WorkingDesk>(true);
            if (mapId != null)
            {
                predicate = predicate.And(i => i.MapId.ToString().ToLower().Contains(mapId.ToString().ToLower()));
            }
            if (deskTypeId != null)
            {
                predicate = predicate.And(i => i.DeskTypeId.ToString().ToLower().Contains(deskTypeId.ToString().ToLower()));
            }
            if (number != null)
            {
                predicate = predicate.And(i => i.Number.ToString().ToLower() == number.ToString().ToLower());
            }

            var data = await workingDeskRepository.ListAsync();
            return data.Where(predicate).ToList();
        }

        public async Task<ResponseBase<WorkingDeskResponseDto>> AddWorkingDesk(CreateWorkingDeskDto workingDeskDto)
        {
            var workingDeskResponse = new ResponseBase<WorkingDeskResponseDto>();
            var map = await _dbContext.WorkingDesks.FirstOrDefaultAsync(u => u.Id == workingDeskDto.MapId);
            if (map == null) throw new MapCustomException("Map not found");

            WorkingDesk newWorkingDesk = workingDeskDto.Adapt<WorkingDesk>();
            await WorkingDeskRepository.AddAsync(newWorkingDesk);
            var workingDeskResponseDto = newWorkingDesk.Adapt<WorkingDeskResponseDto>(); // Mapster
            workingDeskResponse.Data = workingDeskResponseDto;

            return workingDeskResponse;
        }
        public Task<ResponseBase<CreateWorkingDeskDto>> DeleteWorkingDesk(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WorkingDeskResponseDto>> GetAllWorkingDesks(int id, CancellationToken cancellationToken = default)
        {
            List<WorkingDeskResponseDto> workingDesks = await dbSet
                .Select(m => m.Adapt<WorkingDeskResponseDto>())
                .Where(m => m.MapId == id)
                .ToListAsync(cancellationToken);
            return workingDesks;
        }

        public Task<ResponseBase<CreateWorkingDeskDto>> GetWorkingDeskById(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WorkingDeskResponseDto>> GetWorkingDesksForEachMap(List<MapResponseDto> maps, CancellationToken cancellationToken = default)
        {
            var workingDeskResponseDtosList = new List<WorkingDeskResponseDto>();
            foreach (var map in maps)
            {
                var workingDesks = await dbSet
                    .Select(m => m.Adapt<WorkingDeskResponseDto>())
                    .Where(m => m.MapId == map.MapId)
                    .ToListAsync(cancellationToken);
                workingDeskResponseDtosList.AddRange(workingDesks);
            };
            return workingDeskResponseDtosList;
        }
    }
}