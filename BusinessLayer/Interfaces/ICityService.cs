using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface ICityService
    {
        Task<City> AddAsync(City city);
        Task DeleteAsync(City city);
        Task<List<City>> ListAsync();
        Task<City> GetByIdAsync(int id);
        Task UpdateAsync(City city);
    }
}
