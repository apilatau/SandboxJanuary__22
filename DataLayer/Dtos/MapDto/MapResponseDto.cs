using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto.MapDto
{
    public class MapResponseDto
    {
        public int MapId { get; set; }
        public int OfficeId { get; set; }
        public int Floor { get; set; }
        public bool HasKitchen { get; set; }
        public bool HasConfRoom { get; set; }
        public ICollection<WorkingDesk> WorkingDesks { get; set; }
    }
}
