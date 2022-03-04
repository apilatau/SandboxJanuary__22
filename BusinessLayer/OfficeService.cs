using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer
{
    public class OfficeService : IOfficeService
    {
        private AppSettings _appSettings;
        private readonly IOfficeRepository _officeRepository;

        public OfficeService(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
            _appSettings = new AppSettings();
        }

        public async Task<Office> AddAsync(Office office) => await _officeRepository.AddAsync(office);

        public async Task<Office> GetByIdAsync(int id) => await _officeRepository.GetByIdAsync(id);

        public async Task UpdateAsync(Office office) => await _officeRepository.UpdateAsync(office);

        public async Task DeleteAsync(Office office) => await _officeRepository.DeleteAsync(office);
    }
}
