namespace TelegramBotAPI.Models
{
    public class Logs
    {
        public int? LogId { get; set; }
        public DateTime? LogTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? EventType { get; set; }
        public string? ObjectName { get; set; }
        public string? ObjectType { get; set; }
        public string? SqlCommand { get; set; }
        public DateTime? EventDate { get; set; }
    }
}
