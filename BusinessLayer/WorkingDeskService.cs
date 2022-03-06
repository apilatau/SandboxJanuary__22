using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using LinqKit;

namespace BusinessLayer
{
    public class WorkingDeskService : IWorkingDeskService
    {
        private readonly IWorkingDeskRepository workingDeskRepository;

        public WorkingDeskService(IWorkingDeskRepository workingDeskRepository)
        {
            this.workingDeskRepository = workingDeskRepository;
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
    }
}
