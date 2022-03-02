namespace DataLayer.Models
{
    public class DeskType : BaseEntity
    {
        public string DeskTypeName { get; set; }

        public virtual ICollection<WorkingDesk> WorkingDesks { get; set; }
    }
}
