using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Reserv
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int WorkingDeskId { get; set; }
        public string BookTypesId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Frequency { get; set; }
    }
}
