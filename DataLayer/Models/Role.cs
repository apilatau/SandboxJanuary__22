using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Role : BaseEntity
    {

        [Required]
        public string RoleName { get; set; }

        [JsonIgnore]
        public ICollection<Userr>? Users { get; set; }
    }
}
