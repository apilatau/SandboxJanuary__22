using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos.OfficeDto
{
    public class OfficeResponseDto
    {
        public int OfficeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public bool Parking { get; set; }
    }
}
