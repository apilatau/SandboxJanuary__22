using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace BusinessLayer
{
    public class WorkingDeskService : IWorkingDeskService
    {
        private readonly IWorkingDeskRepository _workingDeskRepository;

        public WorkingDeskService(IWorkingDeskRepository workingDeskRepository)
        {
            _workingDeskRepository = workingDeskRepository;
        }

        public async Task<List<WorkingDesk>> GetWorkingDesksAsync()
        {
            return await _workingDeskRepository.ListAsync();
        }
    }
}
