using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository officeRepository;
        private readonly AppSettings _appSettings;

        public OfficeService(IOfficeRepository officeRepository)
        {
            _appSettings = new AppSettings();
            officeRepository = officeRepository;
        }

        public async Task<Office> AddAsync(Office office)
        {
            return await officeRepository.AddAsync(office);
        }

        public async Task DeleteAsync(Office office) => await officeRepository.DeleteAsync(office);

        public async Task<Office> GetByIdAsync(int id)
        {
            return await officeRepository.GetByIdAsync(id);
        }

        public async Task<List<Office>> ListAsync()
        {
            return await officeRepository.ListAsync();
        }

        public async Task UpdateAsync(Office office) => officeRepository.UpdateAsync(office);
    }
}
