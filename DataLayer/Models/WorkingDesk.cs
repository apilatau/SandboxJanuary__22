﻿using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class WorkingDesk : BaseEntity
    {
        public int Number { get; set; }
        public string DeskType { get; set; }
        public bool Booked { get; set; }
        public int MapId { get; set; }
        //public Map Map { get; set; }

        public bool HasPC { get; set; }
        public bool HasMonitor { get; set; }
        public bool HasKeyboard { get; set; }
        public bool HasMouse { get; set; }
        public bool HasHeadset { get; set; }
        public bool NextToWindow { get; set; }
    }
}
