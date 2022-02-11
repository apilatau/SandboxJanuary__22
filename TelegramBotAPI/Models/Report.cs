using System.ComponentModel.DataAnnotations;

namespace TelegramBotAPI.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int OfficeId { get; set; }
        public int ReservesId { get; set; }
    }
}
