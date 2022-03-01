using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set;}
    }
}
