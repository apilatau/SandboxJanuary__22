using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class BookingType : BaseEntity
    {
        public string BookType { get; set; }

        [JsonIgnore]
        public ICollection<Reserve>? Reserves { get; set; }
    }
}