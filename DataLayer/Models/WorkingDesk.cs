using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class WorkingDesk : BaseEntity
    {
        public int Number { get; set; }

        public int DeskTypeId { get; set; }
        [JsonIgnore]
        public DeskType? DeskType { get; set; }

        public bool Booked { get; set; }

        public int MapId { get; set; }
        [JsonIgnore]
        public Map? Map { get; set; }

        public bool HasPC { get; set; }
        public bool HasMonitor { get; set; }
        public bool HasKeyboard { get; set; }
        public bool HasMouse { get; set; }
        public bool HasHeadset { get; set; }
        public bool NextToWindow { get; set; }
    }
}
