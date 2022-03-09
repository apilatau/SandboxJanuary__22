using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos.CityDto
{
    public class CityResponseDto
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}