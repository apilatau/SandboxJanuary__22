using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class BookingType : BaseEntity
    {
        public string BookType { get; set; }

        public ICollection<Reserve> Reserves { get; set; }
    }
}
