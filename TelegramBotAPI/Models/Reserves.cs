namespace TelegramBotAPI.Models
{
    public class Reserves
    {
        public int? ReserveId { get; set; }
        public int? EmployeeId { get; set; }
        public int? BookTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public bool Frequency { get; set; }
        public int? WorkingDeskId { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public int? OfficeId { get; set; }
    }
}
