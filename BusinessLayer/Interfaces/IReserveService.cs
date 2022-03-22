using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IReserveService
    {
        Task<List<Reserve>> GetAllReserves(int id = default, CancellationToken cancellationToken = default);

        Task<Reserve> AddAsync(Reserve reserve);
        Task DeleteAsync(Reserve reserve);
        Task<List<Reserve>> ListAsync();
        Task<Reserve> GetByIdAsync(int id);
        Task UpdateAsync(Reserve reserve);
        Task<Reserve> AddInAdvanceAsync(Reserve reserve);


        //  Task<List<ReserveResponseDto>> GetReservesForEachEmployee(List<ReserveResponseDto> reserves, CancellationToken cancellationToken = default);
    }
}