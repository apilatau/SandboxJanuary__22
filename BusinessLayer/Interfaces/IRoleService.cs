using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IRoleService
    {
        Task<Role> AddAsync(Role role);
        Task DeleteAsync(Role role);
        Task<List<Role>> ListAsync();
        Task<Role> GetByIdAsync(int id);
        Task UpdateAsync(Role role);
    }
}