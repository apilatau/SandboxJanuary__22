using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DataLayer.Models
{
    public class Reserve : BaseEntity
    {
        public int WorkingDeskId { get; set; }
        public WorkingDesk WorkingDesk { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
       // public User User { get; set; } 

        public int BookingTypeId { get; set; }
        public BookingType BookingType { get; set; }
        public bool IsReccuring { get; set; }
        public int Frequency { get; set; }
    }
}
