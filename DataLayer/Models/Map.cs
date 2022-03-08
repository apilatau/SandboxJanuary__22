using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class Map : BaseEntity
    {
        public int Floor { get; set; }
        public bool HasKitchen { get; set; }
        public bool HasConfRoom { get; set; }
        public int OfficeId { get; set; }

        [JsonIgnore]
        public ICollection<WorkingDesk>? WorkingDesks { get; set; }
    }
}
