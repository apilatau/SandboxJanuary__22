using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Lastname { get; set; }

        public DateTime StartJob { get; set; }
        public bool IsWorking { get; set; }

        public bool HaveVacation { get; set; }

        public string CurrentCountry { get; set; }
        public string CurrentPosition { get; set; }

        //public ICollection<Reserve> Reserves { get; set; }
        //public ICollection<Report> Reports { get; set; }
        //public ICollection<Log> Logs { get; set; }
    }
}
