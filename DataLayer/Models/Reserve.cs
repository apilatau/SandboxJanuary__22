using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class Reserve : BaseEntity
    {
        public int WorkingDeskId { get; set; }
        [JsonIgnore]
        public WorkingDesk? WorkingDesk { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int UserrId { get; set; }
        [JsonIgnore]
        public Userr? User { get; set; }
        public int BookingTypeId { get; set; }
        [JsonIgnore]
        public BookingType? BookingType { get; set; }
        public bool IsReccuring { get; set; }
        public int Frequency { get; set; }
        public int OfficeId { get; set; }
        [JsonIgnore]
        public Office? Office { get; set; }
    }
}
