using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<Userr> AddAsync(Userr user);
        Task DeleteAsync(Userr user);
        Task<List<Userr>> ListAsync();
        Task<Userr> GetByIdAsync(int id);
        Task UpdateAsync(Userr user);
        Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model);
    }
}
