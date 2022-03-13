using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Dto.MapDto;
using DataLayer.Dtos.OfficeDto;
using DataLayer.IRepositories;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Responses;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class MapService : IMapService
    {

        }

        public async Task<int> AddMap(Map map)
        {

        }

        public async Task<int> DeleteMap(int id)
        {
            var map = await _dbContext.Maps.FirstOrDefaultAsync(x => x.Id == id);
            if(map != null)
            {
                await _mapRepository.DeleteAsync(map);
            }

            return id;
        }

        public async Task<List<Map>> GetAllMaps(int officeId = default)
        {
            List<Map> maps = await dbSet
                .Select(x => x)
                .Where(m => m.Id == officeId)
                .ToListAsync();
            return maps;
        }

        public async Task<Map> GetMapById(int id)
        {
            var map = await _dbContext.Maps.FirstOrDefaultAsync(x => x.Id == id);
            return map;
        }

        public async Task<List<Map>> GetMapsForEachOffice(List<Office> offices)
        {
            var maps = new List<Map>();
            foreach (var office in offices)
            {
                var mapsofEachOffice = dbSet
                    .Select(x => x)
                    .Where(m => m.OfficeId == office.Id);
                maps.AddRange(mapsofEachOffice);
            };
            return maps;
        }
    }
}


//public async Task<ResponseBase<MapResponseDto>> AddMap(CreateMapDto mapDto)
//{
//    var mapResponse = new ResponseBase<MapResponseDto>();
//    var office = await _dbContext.Offices.FirstOrDefaultAsync(u => u.Id == mapDto.OfficeId);
//    if (office == null) throw new OfficeCustomException("Office not found");
//    Map newMap = mapDto.Adapt<Map>();
//    await MapRepository.AddAsync(newMap);
//    var mapResponseDto = newMap.Adapt<MapResponseDto>(); // Mapster
//    mapResponse.Data = mapResponseDto;
//    return mapResponse;
//}

//public async Task<List<MapResponseDto>> GetMapsForEachOffice(List<OfficeResponseDto> offices, CancellationToken cancellationToken = default)
//{
//    var mapResponseDtosList = new List<MapResponseDto>();
//    foreach (var office in offices)
//    {
//        var maps = await dbSet
//            .Select(m => m.Adapt<MapResponseDto>())
//            .Where(m => m.OfficeId == office.OfficeId)
//            .ToListAsync(cancellationToken);
//        mapResponseDtosList.AddRange(maps);
//    };
//    return mapResponseDtosList;
//}


//public Task<ResponseBase<CreateMapDto>> DeleteMap(int id, CancellationToken cancellationToken = default)
//{
//    throw new NotImplementedException();
//}

//public async Task<List<MapResponseDto>> GetAllMaps(int id, CancellationToken cancellationToken = default)
//{
//    List<MapResponseDto> maps = await dbSet
//        .Select(m => m.Adapt<MapResponseDto>())
//        .Where(m => m.OfficeId == id)
//        .ToListAsync(cancellationToken);
//    return maps;
//}
//public Task<ResponseBase<CreateMapDto>> GetMapById(int id, CancellationToken cancellationToken = default)
//{
//    throw new NotImplementedException();
//}