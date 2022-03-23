using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IReserveService
    {
        Task<Reserve> BookByParameters(int userId, int workingDeskId, DateTime startDate, DateTime endDate, DayOfWeek[] selectedDays, int frequency);
        

        Task<Reserve> AddAsync(Reserve reserve);
        Task DeleteAsync(Reserve reserve);
        Task<List<Reserve>> ListAsync();
        Task<Reserve> GetByIdAsync(int id);
        Task<List<Reserve>> GetByOfficeId(int officeId,DateTime startDate);
        Task UpdateAsync(Reserve reserve);
        Task<Reserve> AddInAdvanceAsync(Reserve reserve);

        public string TestBot();
    }
}