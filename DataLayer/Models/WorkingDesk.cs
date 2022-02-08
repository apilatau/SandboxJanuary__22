using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class WorkingDesk
    {
        public int Id { get; set; }
        public int Number { get; set; } //means which number of table is 
        public string Type { get; set; }
        public int MapId { get; set; }
        public bool HasPC { get; set; }
        public bool HasMonitor { get; set; }
        public bool HasKeyboard { get; set; }
        public bool HasMouse { get; set; }
        public bool HasHeadset { get; set; }
        public bool NextToWindow { get; set; }
    }
}
