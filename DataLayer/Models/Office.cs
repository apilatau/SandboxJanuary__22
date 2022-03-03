using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Office : BaseEntity
    {
        [Key]
        [Required]
        public int OfficeId { get; set; }
        public City City { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Parking { get; set; } = true;
    }
}
