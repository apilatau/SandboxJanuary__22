using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingDeskController : Controller
    {
        
        //[HttpPost]
        //public async Task<ActionResult<WorkingDesk>> UploadWorkplaceFile()
        //{
        //    return CreatedAtAction(null,null);
        //}

        //[HttpPost]
        //public async Task<ActionResult<WorkingDesk>> CreateWorkplace(WorkingDesk workingDesk)
        //{
        //    return CreatedAtAction(null, new { Id = workingDesk.Id });
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<WorkingDesk>>> GetWorkplaces()
        //{
        //    return Ok();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<WorkingDesk>> GetWorkingplace(int id)
        //{
        //    return Ok();
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateWorkingplace(int id, WorkingDesk workingDesk)
        //{
        //    return Ok();
        //}
    }
}
