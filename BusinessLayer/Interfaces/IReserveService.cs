using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IReserveService
    {
        Task<Reserve> AddAsync(Reserve reserve);
        Task DeleteAsync(Reserve reserve);
        Task<List<Reserve>> ListAsync();
        Task<Reserve> GetByIdAsync(int id);
        Task UpdateAsync(Reserve reserve);
    }
}
