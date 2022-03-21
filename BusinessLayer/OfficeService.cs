using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Dtos.CityDto;
using DataLayer.Dtos.OfficeDto;
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
        private readonly OfficeRepository _officeRepository;
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<Office> dbSet;
        private readonly IOfficeRepository officeRepository;

        public OfficeService(ApplicationDbContext dbContext, IOfficeRepository officeRepository)
        {
            this.officeRepository = officeRepository;
            _dbContext = dbContext;
            dbSet = _dbContext.Set<Office>();
        }

        public async Task<ResponseBase<OfficeResponseDto>> AddOffice(CreateOfficeDto officeDto)
        {
            var officeResponse = new ResponseBase<OfficeResponseDto>();
            var city = await _dbContext.Offices.FirstOrDefaultAsync(u => u.Id == officeDto.CityId);
            if (city == null) throw new OfficeCustomException("City not found");

            Office newOffice = officeDto.Adapt<Office>();
            await _officeRepository.AddAsync(newOffice);
            var officeResponseDto = newOffice.Adapt<OfficeResponseDto>(); // Mapster
            officeResponse.Data = officeResponseDto;

            return officeResponse;
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


        public Task<ResponseBase<OfficeResponseDto>> DeleteOffice(int id, CancellationToken cancellationToken = default)
           
        {
            throw new NotImplementedException();
                
        }

        public async Task<List<OfficeResponseDto>> GetAllOffices(int Cityid = default, CancellationToken cancellationToken = default)
        {
            if (Cityid != null)
            {          
                List<OfficeResponseDto> offices = await dbSet
                .Select(m => m.Adapt<OfficeResponseDto>())
                .Where(m => m.CityId == Cityid)
                .ToListAsync(cancellationToken);
                return offices;              
            }
            else
            {             
                List<OfficeResponseDto> offices = await dbSet
                .Select(m => m.Adapt<OfficeResponseDto>())
                .ToListAsync(cancellationToken);
                return offices;
            }   
        }

        public Task<ResponseBase<OfficeResponseDto>> GetOfficeById(int id, CancellationToken cancellationToken = default)
            
        {
            throw new NotImplementedException();
                
        }

        public async Task<List<OfficeResponseDto>> GetOfficesForEachCity(List<CityResponseDto> cities, CancellationToken cancellationToken = default)
        {
            var officeResponseDtosList = new List<OfficeResponseDto>();
            foreach (var city in cities)
            {
                var offices = await dbSet
                    .Select(m => m.Adapt<OfficeResponseDto>())
                    .Where(m => m.CityId == city.CityId)
                    .ToListAsync(cancellationToken);
                officeResponseDtosList.AddRange(offices);
            };
            return officeResponseDtosList;
        }
    }
}