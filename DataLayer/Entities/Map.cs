namespace DataLayer.Entities;

public abstract class Map : BaseEntity
{
    public int Floor { get; set; }
    public bool HasKitchen { get; set; }
    public bool HasConfRoom { get; set; }
    public int OfficeId { get; set; }
    public ICollection<WorkingDesk> WorkingDesks { get; set; }
}