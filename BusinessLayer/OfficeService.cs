using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Responses;
using LinqKit;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository officeRepository;
        private AppSettings _appSettings;


        public OfficeService(IOfficeRepository officeRepository)
        {
            _appSettings = new AppSettings();
            this.officeRepository = officeRepository;
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

        public async Task<List<Office>> SearchSpecificOfficePlan(string? name, string? address, int? cityId, int? countryId)
        {
            var predicate = PredicateBuilder.New<Office>(true);
            if (name != null)
            {
                predicate = predicate.And(i => i.Name.ToLower().Contains(name.ToLower()));
            }
            if (address != null)
            {
                predicate = predicate.And(i => i.Address.ToLower().Contains(address.ToLower()));
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

        public async Task UpdateAsync(Office office) => await officeRepository.UpdateAsync(office);    
  
    }
}