using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public bool Parking { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
    }
}
