using System.ComponentModel.DataAnnotations;

namespace TelegramBotAPI.Models
{
    public class Map
    {
        [Key]
        public int MapId { get; set; }
        public int Floor { get; set; }
        public bool HaveKitchen { get; set; }
        public bool ConfRooms { get; set; }
        public int OfficeId { get; set; }

    }
}
