using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    class Office
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public int CityId { get; set; }
		public int CountryId { get; set; }
		public bool Parking { get; set; }
	}
}
