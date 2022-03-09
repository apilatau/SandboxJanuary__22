using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<City>? Cities { get; set;}
    }
}
