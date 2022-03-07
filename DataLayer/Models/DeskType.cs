using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class DeskType : BaseEntity
    {
        public string DeskTypeName { get; set; }

        [JsonIgnore]
        public ICollection<WorkingDesk>? WorkingDesks { get; set; }
    }
}
