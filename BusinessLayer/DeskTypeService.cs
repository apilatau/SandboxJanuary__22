using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DeskTypeService : IDeskTypeService
    {
        private readonly IDeskTypeRepository _desktypeRepository;

        public DeskTypeService(IDeskTypeRepository desktypeRepository)
        {
            _desktypeRepository = desktypeRepository;
        }

        public async Task<DeskType> AddAsync(DeskType deskType)
        {
            return await _desktypeRepository.AddAsync(deskType);
        }

        public async Task DeleteAsync(DeskType deskType) =>await _desktypeRepository.DeleteAsync(deskType);

        public async Task<DeskType> GetByIdAsync(int id)
        {
            return await _desktypeRepository.GetByIdAsync(id);
        }

        public async Task<List<DeskType>> ListAsync()
        {
            return await _desktypeRepository.ListAsync();
        }

        public async Task UpdateAsync(DeskType deskType) => await _desktypeRepository.DeleteAsync(deskType);
    }
}
