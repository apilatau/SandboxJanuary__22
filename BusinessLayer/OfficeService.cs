using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Dto.MapDto;
using DataLayer.Dtos.CityDto;
using DataLayer.Dtos.OfficeDto;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Responses;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OfficeService : IOfficeService
    {
        private readonly OfficeRepository _officeRepository;
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<Office> dbSet;

        public OfficeService(ApplicationDbContext dbContext)
        {
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
        public Task<ResponseBase<OfficeResponseDto>> DeleteOffice(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OfficeResponseDto>> GetAllOffices(int Cityid=default, CancellationToken cancellationToken = default)
        {
            if(Cityid != null)
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
