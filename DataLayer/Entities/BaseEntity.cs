namespace PresentationLayer.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; } = null;
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
    
}
