using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IWorkingDeskService
    {

        Task<WorkingDesk> AddAsync(WorkingDesk workingDesk);
        Task DeleteAsync(WorkingDesk workingDesk);
        Task<List<WorkingDesk>> ListAsync();
        Task<WorkingDesk> GetByIdAsync(int id);
        Task UpdateAsync(WorkingDesk workingDesk);
    }
}
