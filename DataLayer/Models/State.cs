using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class State : BaseEntity
    {
        public Int64? OwnerTelegramId { get; set; }
        public Int64? TargetTelegramId { get; set; }
        public City?  cityId { get; set; }
        public Office? officeId { get; set; }
        public int? WorkingDeskNumber { get; set; }
        public string? startDay { get; set; }
        public string? startMonth { get; set; }
        public string? endDay { get; set; }
        public string? endMonth { get; set; }
        public int userNumber { get; set; }
        public int level { get; set; }
    }
}
