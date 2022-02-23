using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;

namespace BusinessLayer
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task DeleteAsync(User user) => await _userRepository.DeleteAsync(user);

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<List<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task UpdateAsync(User user) => await _userRepository.UpdateAsync(user);
    }
}