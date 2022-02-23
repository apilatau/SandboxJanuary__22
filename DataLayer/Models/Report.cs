using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Report : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CountryId { get; set; }
        //public Country Country { get; set; }
        public int CityId { get; set; }
        //public City City { get; set; }
        public int OfficeId { get; set; }
        //public Office Office { get; set; }
        public int ReserveId { get; set; }
        public Reserve Reserve { get; set; }
    }
}
