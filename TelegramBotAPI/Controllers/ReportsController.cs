using BusinessLayer.Exceptions;
using DataLayer;
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

        public ReportsController(ReportTimeline _reportTimeline)
        {
            reportTimeline = _reportTimeline;
        }


        [HttpGet]
        public async Task<IActionResult> ReportByOffice(int officeId, bool full,DateTime startDate, DateTime finishDate)
        {
            if (reportTimeline.Weekly)
            {

            }
            else if (reportTimeline.Monthly)
            {

            }
            else throw new ReportCustomException();

            return Ok();
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
