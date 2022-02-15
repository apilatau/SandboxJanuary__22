using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Parking { get; set; }
        public int CityId { get; set; }
        //public City City { get; set; }
    }
}
