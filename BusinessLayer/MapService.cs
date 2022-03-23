using BusinessLayer.Interfaces;
using DataLayer.IRepositories;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MapService : IMapService
    {
        private readonly IMapRepository mapRepository;
        private readonly AppSettings _appSettings;

        public MapService(IMapRepository mapRepository)
        {
            _appSettings = new AppSettings();
            mapRepository = mapRepository;
        }

        public async Task<Map> AddAsync(Map map)
        {
            return await mapRepository.AddAsync(map);
        }

        public async Task DeleteAsync(Map map) => await mapRepository.DeleteAsync(map);

        public async Task<Map> GetByIdAsync(int id)
        {
            return await mapRepository.GetByIdAsync(id);
        }

        public async Task<List<Map>> ListAsync()
        {
            return await mapRepository.ListAsync();
        }

        public Task UpdateAsync(Map map) => mapRepository.UpdateAsync(map);
    }
}
