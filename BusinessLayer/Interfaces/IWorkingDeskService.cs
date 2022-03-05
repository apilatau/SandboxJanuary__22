using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IWorkingDeskService
    {
        public Task<List<WorkingDesk>> GetWorkingDesksAsync();
    }
}
