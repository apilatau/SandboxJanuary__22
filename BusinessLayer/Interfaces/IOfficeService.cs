using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IOfficeService
    {
        public Task<List<Office>> SearchSpecificOfficePlan(string? name, string? address, int? cityId, int? countryId);
        Task<Office> AddAsync(Office office);
        Task DeleteAsync(Office office);
        Task<List<Office>> ListAsync();
        Task<Office> GetByIdAsync(int id);
        Task UpdateAsync(Office office);
    }
}