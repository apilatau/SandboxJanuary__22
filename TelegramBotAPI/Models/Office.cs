namespace TelegramBotAPI.Models
{
    public class Office
    {
        public int? OfficeId { get; set; }
        public string? Name { get; set; }
        public bool? IsCityCenter { get; set; }
        public string? Address { get; set; }
        public int? CityId { get; set; }
        public bool IsNearCafe { get; set; }
        //public bool IsParking { get; set; }
        //public int? ParkingId { get; set; }
    }
}
