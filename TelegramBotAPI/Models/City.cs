namespace TelegramBotAPI.Models
{
    public class City
    {
        public int? CityId { get; set; }
        public string? Name { get; set; }
        public bool IsCityCenter { get; set; }
        public int CountryId { get; set; }
    }
}
