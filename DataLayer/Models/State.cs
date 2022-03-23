using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class State : BaseEntity
    {
        public Int64? OwnerTelegramId { get; set; }
        public Int64? TargetTelegramId { get; set; }
        public int? WorkingDeskNumb { get; set; }
        public string? Startday { get; set; }
        public string? startmonth { get; set; }
        public string? enday { get; set; }
        public string? endmonth { get; set; }
        public int UserrNum { get; set; }
        public int? BookingTypeNum { get; set; }
        public bool? IsReccuring { get; set; }
        public int? Frequency { get; set; }
        public int Level { get; set; }
    }
}
