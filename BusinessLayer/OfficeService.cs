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