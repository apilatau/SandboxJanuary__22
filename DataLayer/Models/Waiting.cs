using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Waiting : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int WorkingDeskId { get; set; }
        public WorkingDesk WorkingDesk { get; set; }
    }
}
