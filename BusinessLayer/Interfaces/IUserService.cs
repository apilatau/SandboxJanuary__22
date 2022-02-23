using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<User> AddAsync(User user);
        Task DeleteAsync(User user);
        Task<List<User>> ListAsync();
        Task<User> GetByIdAsync(int id);
        Task UpdateAsync(User user);
    }
}
