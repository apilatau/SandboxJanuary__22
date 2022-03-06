using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingDeskController : ControllerBase
    {
        private readonly IWorkingDeskService workingDeskService;
        private readonly ILogger<WorkingDeskController> logger;

        public WorkingDeskController(IWorkingDeskService workingDeskService,
            ILogger<WorkingDeskController> logger)
        {
            this.workingDeskService = workingDeskService;
            this.logger = logger;
        }

        [HttpGet("SearchWorkspace")]
        public async Task<List<WorkingDesk>> SearchSpecificWorkSpace(int? mapId, int? deskTypeId, int? number)
        {
            return await workingDeskService.SearchSpecificWorkSpace(mapId, deskTypeId, number);
        }
    }
}
