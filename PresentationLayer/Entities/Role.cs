namespace PresentationLayer.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
    
}
