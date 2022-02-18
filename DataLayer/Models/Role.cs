using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
