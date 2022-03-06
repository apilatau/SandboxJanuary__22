using BusinessLayer;
using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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


        [HttpPost]
        [Authorize]
        public async Task<WorkingDesk> AddWorkingDesk(WorkingDesk workingDesk)
        {
            return await _workingDeskService.AddAsync(workingDesk); 
        }
        [HttpPut]
        [Authorize]
        public async Task UpdateWorkingDesk(WorkingDesk workingDesk) => await _workingDeskService.UpdateAsync(workingDesk);
        

        [HttpGet]
        public async Task<ActionResult<List<WorkingDesk>>> GetWorkingDesksAsync()
        {
            return await _workingDeskService.ListAsync();
        }
        

        
    }
}
