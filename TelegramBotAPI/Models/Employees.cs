namespace TelegramBotAPI.Models
{
    public class Employees
    {
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? StartingDate { get; set; }
        public bool IsWorking { get; set; }
        public bool HaveVacation { get; set; }
        //public string? CurrentLocCoutnry { get; set; }
        public string? Position { get; set; }
        public int? ReserveId { get; set; }
    }
}
