using DataLayer.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : Controller
    {
        private readonly ILogger<OfficeController> _logger;

        public OfficeController(ApplicationDbContext dbContext, ILogger<OfficeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddOffice()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOffice()
        {
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
