using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class WorkingDesk : BaseEntity
    {
        public int Number { get; set; }
        public int OfficeId { get; set; }
        [JsonIgnore]
        public Office? Office { get; set; }
        public bool HasComputer { get; set; }
        public bool NextToWindow { get; set; }
        public int CityId { get; set; }
    }
}
