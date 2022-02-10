using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class BookingType
    {
        public int Id { get; set; }
        public string BookType { get; set; }

        public ICollection<Reserve> Reserves { get; set; }
    }
}
