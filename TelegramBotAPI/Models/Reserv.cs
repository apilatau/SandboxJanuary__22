using System.ComponentModel.DataAnnotations;

namespace TelegramBotAPI.Models
{
    public class Reserv
    {
        [Key]
        public int ReservId { get; set; }
        public int UserId { get; set; }
        public int BookingTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Frequency { get; set; }
    }
}
