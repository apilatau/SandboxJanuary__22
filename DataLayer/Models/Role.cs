using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Role : BaseEntity
    {

       // [Required]
        public string RoleName { get; set; }
        //public virtual ICollection<User> Users { get; set; }
    }
}
