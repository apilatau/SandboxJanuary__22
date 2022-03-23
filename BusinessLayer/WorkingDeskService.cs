using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using LinqKit;

namespace BusinessLayer
{
    public class WorkingDeskService : IWorkingDeskService
    {
        private readonly IWorkingDeskRepository _workingDeskRepository;
        private AppSettings _appSettings;
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<WorkingDesk> dbSet;

        public WorkingDeskService(IWorkingDeskRepository workingDeskRepository, ApplicationDbContext dbContext)
        {
            _workingDeskRepository = workingDeskRepository;
            _appSettings = new AppSettings();
            _dbContext = dbContext;
            dbSet = _dbContext.Set<WorkingDesk>();
        }

        public async Task<int> AddAsync(WorkingDesk workingDesk)
        {
            await _workingDeskRepository.AddAsync(workingDesk);
            return workingDesk.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var workingDesk = await _dbContext.WorkingDesks.FirstOrDefaultAsync(x => x.Id == id);
            if (workingDesk != null)
            {
                await _workingDeskRepository.DeleteAsync(workingDesk);
            }
            await _workingDeskRepository.SaveChangesAsync();

            return id;
        }

        public async Task<WorkingDesk> GetByIdAsync(int id)
        {
            return await _workingDeskRepository.GetByIdAsync(id);
        }

        public async Task<List<WorkingDesk>> ListAsync()
        {
            return await _workingDeskRepository.ListAsync();
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

            var data = await _workingDeskRepository.ListAsync();
            return data.Where(predicate).ToList();
        }

        public async Task UpdateAsync(WorkingDesk workingDesk) => await _workingDeskRepository.UpdateAsync(workingDesk);

        public async Task<List<WorkingDesk>> GetAllWorkingDesks(int id)
        {
            List<WorkingDesk> workingDesks = await dbSet
                .Select(m => m)
                .Where(m => m.MapId == id)
                .ToListAsync();
            return workingDesks;
        }

        public async Task<List<WorkingDesk>> GetWorkingDesksForEachMap(List<Map> maps)
        {
            var workingDesks = new List<WorkingDesk>();
            foreach (var map in maps)
            {
                var workingDesksofEachMap = await dbSet
                    .Select(m => m)
                    .Where(m => m.MapId == map.Id)
                    .ToListAsync();
                workingDesks.AddRange(workingDesksofEachMap);
            };
            return workingDesks;
        }
    }
}


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