using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Dto.MapDto;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Responses;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessLayer
{
    public class MapService : IMapService
    {

        private readonly MapRepository MapRepository;
        private readonly OfficeRepository OfficeRepository;
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<Map> dbSet;

        public MapService(ApplicationDbContext dbContext, IUnitOfWork _unitOfWork)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<Map>();
        }

        // DOING => DONE
        public async Task<MapResponse<MapResponseDto>> AddMap(CreateMapDto mapDto)
        {
            var mapResponse = new MapResponse<MapResponseDto>();
            var office = await _dbContext.Offices.FirstOrDefaultAsync(u => u.Id == mapDto.OfficeId);
            if (office == null) throw new Exception("Office not found");
            Map newMap = mapDto.Adapt<Map>();
            await MapRepository.AddMap(newMap);
            var mapResponseDto = newMap.Adapt<MapResponseDto>(); // Mapster
            mapResponse.Data = mapResponseDto;

            return mapResponse;
        }
        public Task<MapResponse<CreateMapDto>> DeleteMap(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        // DOING => DONE
        public async Task<List<MapResponseDto>> GetAllMaps(CancellationToken cancellationToken = default)
        {
            List<MapResponseDto> maps = await dbSet
                .Select(m=> m.Adapt<MapResponseDto>())
                .ToListAsync(cancellationToken);
            return maps;
        }

        public Task<MapResponse<CreateMapDto>> GetMapById(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
