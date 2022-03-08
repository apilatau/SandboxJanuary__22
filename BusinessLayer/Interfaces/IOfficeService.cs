using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IOfficeService
    {
        public Task<List<Office>> SearchSpecificOfficePlan(string? name, string? address, int? cityId, int? countryId);
    }
}
