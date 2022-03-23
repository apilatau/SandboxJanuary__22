using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class WorkingDesk : BaseEntity
    {
        public int Number { get; set; }

        //public int DeskTypeId { get; set; }
        //[JsonIgnore]
        //public DeskType? DeskType { get; set; }

        //public int MapId { get; set; }
        //public Map? Map { get; set; }

        public bool HasComputer { get; set; }
        public bool NextToWindow { get; set; }

        public int CityId { get; set; }
        //public City city { get; set; }
    }
}
