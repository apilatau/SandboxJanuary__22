using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IReserveService
    {
        Task<Reserve> BookByParameters(int userId, int workingDeskId, DateTime startDate, DateTime endDate, DayOfWeek[] selectedDays, int frequency);
        Task<List<ReserveResponseDto>> GetAllReserves(int id = default, CancellationToken cancellationToken = default);
        public Task EditBookingForAdminsAsync(int booking_id, Reserve reserve);


        Task<Reserve> AddAsync(Reserve reserve);
        Task DeleteAsync(Reserve reserve);
        Task<List<Reserve>> ListAsync();
        Task<Reserve> GetByIdAsync(int id);
        Task UpdateAsync(Reserve reserve);
        Task<Reserve> AddInAdvanceAsync(Reserve reserve);


        //  Task<List<ReserveResponseDto>> GetReservesForEachEmployee(List<ReserveResponseDto> reserves, CancellationToken cancellationToken = default);
        public string TestBot();
    }
}