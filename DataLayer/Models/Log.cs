using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Logtime { get; set; }
        public int EmployeesId { get; set; }
        public string EventType { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public string SqlCommand { get; set; }
        public DateTime EventDate { get; set; }
    }
}
