using BusinessLayer.Exceptions;
using DataLayer;
using DataLayer.Data;
using DataLayer.Dtos.ReportDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        ReportTimeline reportTimeline;
        ApplicationDbContext _dbContext;

        public ReportsController(ReportTimeline _reportTimeline, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            reportTimeline = _reportTimeline;
        }


        [HttpGet]
        public async Task<IActionResult> ReportByOffice(RequestOfficeReportDto requestOfficeReportDto)
        {
            var office =  _dbContext.Offices
        }
        
        [HttpGet]
        public async Task<IActionResult> ReportByCity(int cityId, bool full,DateTime startDate, DateTime finishDate)
        {
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> ReportByFloor(int officeId, int floorId, bool full,DateTime startDate, DateTime finishDate)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ReportByEmployee(int officeId, int floorId, bool full, DateTime startDate, DateTime finishDate)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ReportAllOffices(bool full,DateTime startDate, DateTime finishDate)
        {
            return Ok();
        }

    }
}
