using BusinessLayer;
using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingDeskController : ControllerBase
    {
        private readonly IWorkingDeskService _workingDeskService;
        private readonly ILogger<WorkingDeskController> _logger;
        public WorkingDeskController(IWorkingDeskService workingDeskService, ILogger<WorkingDeskController> logger)
        {
            _logger = logger;
            _workingDeskService = workingDeskService;
        }


        [HttpPost]
        [Authorize(Roles = "Map Editor")]
        public async Task<WorkingDesk> AddWorkingDesk(WorkingDesk workingDesk)
        {
            return await _workingDeskService.AddAsync(workingDesk); 
        }

        [HttpPut]
        [Authorize(Roles = "Map Editor")]
        public async Task UpdateWorkingDesk(WorkingDesk workingDesk) => await _workingDeskService.UpdateAsync(workingDesk);

        [HttpDelete]
        [Authorize(Roles = "Map Editor")]
        public async Task DeleteWorkingDesk(WorkingDesk workingDesk) => await _workingDeskService.DeleteAsync(workingDesk);


        [HttpGet]
        public async Task<ActionResult<List<WorkingDesk>>> GetWorkingDesksAsync()
        {
            return await _workingDeskService.ListAsync();
        }

        [HttpGet("SearchWorkspace")]
        public async Task<List<WorkingDesk>> SearchSpecificWorkSpace(int? mapId, int? deskTypeId, int? number)
        {
            return await _workingDeskService.SearchSpecificWorkSpace(mapId, deskTypeId, number);
        }


    }
}
