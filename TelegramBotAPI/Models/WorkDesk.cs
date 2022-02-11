using System.ComponentModel.DataAnnotations;

namespace TelegramBotAPI.Models
{
    public class WorkDesk
    {
        [Key]
        public int WorkingDeskId { get; set; }
        public string DeskType { get; set; }
        public int Number { get; set; }
        public int BookId { get; set; }
        public int MapId { get; set; }
        public int OfficeId { get; set; }
        public bool HasPc { get; set; }
        public bool HasMonitor { get; set; }
        public bool HasKeyboard { get; set; }
        public bool HasHeadset { get; set; }
        public bool IsBig { get; set; }
        public bool IsClosed { get; set; }
        public bool IsNearWindow { get; set; }
    }
}
