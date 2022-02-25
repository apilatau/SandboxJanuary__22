using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class User : BaseEntity
    {
        public int TelegramId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime EmploymentStart { get; set; }
        public DateTime EmploymentEnd { get; set; }

        public bool IsWorking { get; set; }
        public bool HaveVacation { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

    }
}
