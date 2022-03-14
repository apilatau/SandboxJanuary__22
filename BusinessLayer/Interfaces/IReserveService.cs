using DataLayer.Dtos.ReserveDto;
using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IReserveService
    {
        Task<List<ReserveResponseDto>> GetAllReserves(int id = default, CancellationToken cancellationToken = default);
        public Task EditBookingForAdminsAsync(int booking_id, Reserve reserve);

        //  Task<List<ReserveResponseDto>> GetReservesForEachEmployee(List<ReserveResponseDto> reserves, CancellationToken cancellationToken = default);
    }
}