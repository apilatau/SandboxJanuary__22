using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IOfficeService
    {
        Task<Office> AddAsync(Office office);
        Task DeleteAsync(Office office);
        Task<List<Office>> ListAsync();
        Task<Office> GetByIdAsync(int id);
        Task UpdateAsync(Office office);
    }
}
