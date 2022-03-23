using DataLayer.Dtos.ReserveDto;
using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IReserveService
    {
        Task<Reserve> BookByParameters(int userId, int workingDeskId, DateTime startDate, DateTime endDate, DayOfWeek[] selectedDays, int frequency);
        Task<List<ReserveResponseDto>> GetAllReserves(int id = default, CancellationToken cancellationToken = default);
        Task DeleteAsync(int reserveId);
        Task<Reserve> GetByIdAsync(int id);
        Task TimeChecker(List<Reserve> reserves);
        Task<List<Reserve>> ListAsync();

        //  Task<List<ReserveResponseDto>> GetReservesForEachEmployee(List<ReserveResponseDto> reserves, CancellationToken cancellationToken = default);
    }
}