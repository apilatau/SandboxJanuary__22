using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos.ReserveDto
{
    public class ReserveResponseDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public int BookingTypeId { get; set; }
        public BookingType BookingType { get; set; }
        public int Frequency { get; set; }
    }
}