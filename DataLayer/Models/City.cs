using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
