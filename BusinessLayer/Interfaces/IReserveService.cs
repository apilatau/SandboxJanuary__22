using DataLayer.Dtos.ReserveDto;
using DataLayer.Models;
using DataLayer.Responses;

namespace BusinessLayer.Interfaces
{
    public interface IReserveService
    {
        Task<List<ReserveResponseDto>> GetAllReserves(int id = default, CancellationToken cancellationToken = default);
        Task DeleteAsync(Reserve reserve);
        Task TimeChecker(Reserve reserve);

        //  Task<List<ReserveResponseDto>> GetReservesForEachEmployee(List<ReserveResponseDto> reserves, CancellationToken cancellationToken = default);
    }
}