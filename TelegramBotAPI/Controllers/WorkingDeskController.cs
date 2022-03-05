using BusinessLayer;
using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingDeskController : ControllerBase
    {
        private readonly IWorkingDeskService _workingDeskService;
        private readonly ILogger<WorkingDeskController> _logger;
        public WorkingDeskController(WorkingDeskService workingDeskService, ILogger<WorkingDeskController> logger)
        {
            _logger = logger;
            _workingDeskService = workingDeskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkingDesk>>> GetWorkingDesksAsync()
        {
            return await _workingDeskService.GetWorkingDesksAsync();
        }
        

        
    }
}
