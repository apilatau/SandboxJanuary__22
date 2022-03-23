using Newtonsoft.Json;

namespace DataLayer.Models
{
    public class Waiting : BaseEntity
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public Userr? User { get; set; }

        public int WorkingDeskId { get; set; }
        [JsonIgnore]
        public WorkingDesk? WorkingDesk { get; set; }
    }
}
