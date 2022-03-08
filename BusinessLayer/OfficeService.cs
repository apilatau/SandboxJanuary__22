using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using LinqKit;

namespace BusinessLayer
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository officeRepository;

        public OfficeService(IOfficeRepository officeRepository)
        {
            this.officeRepository = officeRepository;
        }
        public async Task<List<Office>> SearchSpecificOfficePlan(string? name, string? address, int? cityId, int? countryId)
        {
            var predicate = PredicateBuilder.New<Office>(true);
            if (name != null)
            {
                predicate = predicate.And(i => i.Name.ToString().ToLower().Contains(name.ToString().ToLower()));
            }
            if (address != null)
            {
                predicate = predicate.And(i => i.Address.ToString().ToLower().Contains(address.ToString().ToLower()));
            }
            if (cityId != null)
            {
                predicate = predicate.And(i => i.CityId.ToString().ToLower() == cityId.ToString().ToLower());
            }
            if (countryId != null)
            {
                predicate = predicate.And(i => i.CountryId.ToString().ToLower() == countryId.ToString().ToLower());
            }

            var data = await officeRepository.ListAsync();
            return data.Where(predicate).ToList();
        }
    }
}
