using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IOfficeService
    {
        Task<Office> AddAsync(Office office);
        Task<Office> GetByIdAsync(int id);
        Task UpdateAsync(Office office);
        Task DeleteAsync(Office office);
    }
}
