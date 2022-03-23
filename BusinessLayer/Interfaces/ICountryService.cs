using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICountryService
    {
        Task<Country> AddAsync(Country country);
        Task DeleteAsync(Country country);
        Task<List<Country>> ListAsync();
        Task<Country> GetByIdAsync(int id);
        Task UpdateAsync(Country country);
    }
}
