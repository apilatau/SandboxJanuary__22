using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DeskType : BaseEntity
    {
        public string DeskTypeName { get; set; }

        public ICollection<WorkingDesk> WorkingDesks { get; set; }
    }
}
