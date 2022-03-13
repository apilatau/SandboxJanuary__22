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
        private readonly IOfficeRepository _officeRepository;
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<Office> dbSet;
        private readonly IOfficeRepository officeRepository;

        public OfficeService(ApplicationDbContext dbContext, IOfficeRepository officeRepository)
        {
            this.officeRepository = officeRepository;
            _dbContext = dbContext;
            dbSet = _dbContext.Set<Office>();
            _officeRepository = officeRepository;
        }

        public async Task<int> AddOffice(Office office)
        {
            var city = await _dbContext.Cities.FirstOrDefaultAsync(u => u.Id == office.CityId);
            if (city == null) throw new OfficeCustomException("City not found");
            await _officeRepository.AddAsync(office);
            await _officeRepository.SaveChangesAsync();
        }

        public async Task<int> DeleteOffice(int id)
        {

        }

        public async Task<List<Office>> GetOfficesForEachCity(List<City> cities)
        {
            var offices = new List<Office>();
            foreach (var city in cities)
            {
                var officesofEachCity = dbSet
                    .Select(m => m)
                    .Where(m => m.CityId == city.Id);
                offices.AddRange(officesofEachCity);
            };
            return offices;
        }
    }
}


//public async Task<ResponseBase<OfficeResponseDto>> AddOffice(CreateOfficeDto officeDto)
//{
//    var officeResponse = new ResponseBase<OfficeResponseDto>();
//    var city = await _dbContext.Offices.FirstOrDefaultAsync(u => u.Id == officeDto.CityId);
//    if (city == null) throw new OfficeCustomException("City not found");

//    Office newOffice = officeDto.Adapt<Office>();
//    await _officeRepository.AddAsync(newOffice);
//    var officeResponseDto = newOffice.Adapt<OfficeResponseDto>(); // Mapster
//    officeResponse.Data = officeResponseDto;

//    return officeResponse;
//}

//public async Task<List<OfficeResponseDto>> GetOfficesForEachCity(List<CityResponseDto> cities, CancellationToken cancellationToken = default)
//{
//    var officeResponseDtosList = new List<OfficeResponseDto>();
//    foreach (var city in cities)
//    {
//        var offices = await dbSet
//            .Select(m => m.Adapt<OfficeResponseDto>())
//            .Where(m => m.CityId == city.CityId)
//            .ToListAsync(cancellationToken);
//        officeResponseDtosList.AddRange(offices);
//    };
//    return officeResponseDtosList;
//}