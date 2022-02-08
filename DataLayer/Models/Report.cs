using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int OfficeId { get; set; }
        public int ReservId { get; set; } 
    }
}
