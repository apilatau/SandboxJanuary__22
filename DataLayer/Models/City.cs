using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public int CountryId { get; set; }
        [JsonIgnore]
        public Country? Country { get; set; }

        [JsonIgnore]
        public ICollection<Userr>? Users { get; set; }
    }
}
