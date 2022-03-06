using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class Reserve : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; } 

        public int BookingTypeId { get; set; }
        [JsonIgnore]
        public BookingType? BookingType { get; set; }

        public int Frequency { get; set; }
    }
}
