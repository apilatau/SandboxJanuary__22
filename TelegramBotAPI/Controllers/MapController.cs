using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : Controller
    {
        private readonly ILogger<MapController> _logger;

        public MapController(ILogger<MapController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Map>>  GetMap(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Map>> CreateMap(Map map)
        {

            return CreatedAtAction(null, 
            new{ Id = map.Id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMap(int id, Map map)
        {
            return Ok();
        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMap(int id)
        {
            return Ok();
        }

        
    }
}
