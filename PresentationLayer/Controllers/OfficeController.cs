using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class OfficeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOffices()
        {
            return null;
        }

        
    }
}
