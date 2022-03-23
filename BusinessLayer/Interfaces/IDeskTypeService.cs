using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IDeskTypeService
    {
        Task<DeskType> AddAsync(DeskType deskType);
        Task DeleteAsync(DeskType deskType);
        Task<List<DeskType>> ListAsync();
        Task<DeskType> GetByIdAsync(int id);
        Task UpdateAsync(DeskType deskType);
    }
}
