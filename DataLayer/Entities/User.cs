namespace DataLayer.Entities;

public abstract class User : BaseEntity
{
    public int TelegramId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public DateTime EmploymentStart { get; set; }
    public DateTime EmploymentEnd { get; set; }
    public bool IsWorking { get; set; }
    public bool HaveVacation { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
}