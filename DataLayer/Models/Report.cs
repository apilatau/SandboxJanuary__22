using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Report : BaseEntity
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public int CountryId { get; set; }
        
        public int CityId { get; set; }
        
        public int OfficeId { get; set; }
        
        public int ReserveId { get; set; }
        [JsonIgnore]
        public Reserve? Reserve { get; set; }
    }
}
