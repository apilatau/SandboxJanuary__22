using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;

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

    }
}
