using DataLayer.IRepositories;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public class RoleService : IRoleService
    {
        private AppSettings _appSettings;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
           _roleRepository = roleRepository;
            _appSettings =new AppSettings();

    }

        public async Task<Role> AddAsync(Role role)
        {
            return await _roleRepository.AddAsync(role);
        }

        public async Task DeleteAsync(Role role) => _roleRepository.DeleteAsync(role);
        

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<List<Role>> ListAsync()
        {
            return await _roleRepository.ListAsync();
        }

        public async Task UpdateAsync(Role role) => await _roleRepository.UpdateAsync(role);

    }
}
