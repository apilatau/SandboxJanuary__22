namespace PresentationLayer.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime StartJob { get; set; }
        public bool IsWorking { get; set; }
        public bool HaveVacation { get; set; }
        public string CurrentCountry { get; set; }
        public string CurrentPosition { get; set; }
    }
}