using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IMapService
    {
        Task<Map> AddAsync(Map map);
        Task DeleteAsync(Map map);
        Task<List<Map>> ListAsync();
        Task<Map> GetByIdAsync(int id);
        Task UpdateAsync(Map map);
    }
}