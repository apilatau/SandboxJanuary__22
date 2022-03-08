using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Role : BaseEntity
    {

        [Required]
        public string RoleName { get; set; }

        [JsonIgnore]
        public ICollection<User>? Users { get; set; }
    }
}
