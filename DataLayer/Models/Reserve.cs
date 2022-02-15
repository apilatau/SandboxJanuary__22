﻿using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Reserve
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        //public User User { get; set; }

        public int BookingTypeId { get; set; }
        //public BookingType BookingType { get; set; }

        public int Frequency { get; set; }
    }
}
