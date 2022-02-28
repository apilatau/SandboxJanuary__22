using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class City : BaseEntity
    {
        [Key]
        [Required]
        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
