using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IMapService mapService;
        private readonly ILogger<ReserveController> logger;

        public MapController(IMapService mapService, ILogger<ReserveController> logger)
        {
            this.mapService = mapService;
            this.logger = logger;
        }


        [HttpPost]
        [Authorize(Roles = "Map Editor")]
        public async Task<Map> AddMap(Map map)
        {
            return await mapService.AddAsync(map);
        }

        [HttpPut]
        [Authorize(Roles = "Map Editor")]
        public async Task UpdateMap(Map map) => await mapService.UpdateAsync(map);

        [HttpDelete]
        [Authorize(Roles = "Map Editor")]
        public async Task DeleteMap(Map map) => await mapService.DeleteAsync(map);

        [HttpGet("getall")]
        public async Task<List<Map>> ListAsync()
        {
            return await mapService.ListAsync();
        }


    }
}
