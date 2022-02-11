using System.ComponentModel.DataAnnotations;

namespace TelegramBotAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int TelegramId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public DateTime EmploymentStart { get; set; }
        public DateTime EmploymentEnd { get; set; }
        public bool IsWorking { get; set; }
        public bool HaveVacation { get; set; }
        public string Position { get; set; }
    }
}
