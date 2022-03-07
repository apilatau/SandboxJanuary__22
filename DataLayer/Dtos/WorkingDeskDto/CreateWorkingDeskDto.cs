using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos.WorkingDeskDto
{
    public class CreateWorkingDeskDto
    {
        public int Number { get; set; }
        public bool Booked { get; set; }
        public int MapId { get; set; }
        public bool HasPC { get; set; }
        public bool HasMonitor { get; set; }
        public bool HasKeyboard { get; set; }
        public bool HasMouse { get; set; }
        public bool HasHeadset { get; set; }
        public bool NextToWindow { get; set; }
    }
}