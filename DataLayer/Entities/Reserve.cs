namespace DataLayer.Entities;

public abstract class Reserve : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int UserId { get; set; }
    public int BookingTypeId { get; set; }
    public int Frequency { get; set; }
}