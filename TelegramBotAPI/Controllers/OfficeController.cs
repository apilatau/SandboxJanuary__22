using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    
    public class OfficeController : ControllerBase
    {
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
