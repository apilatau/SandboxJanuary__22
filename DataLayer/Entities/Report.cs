namespace PresentationLayer.Entities
{
    public abstract class Report : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int OfficeId { get; set; }
        public int ReserveId { get; set; } 
    }
    
}