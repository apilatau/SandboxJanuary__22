﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Log : BaseEntity
    {
        public DateTime LogTime { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public string EventType { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public string SqlCommand { get; set; }
        public DateTime EventDate { get; set; }
    }
}
