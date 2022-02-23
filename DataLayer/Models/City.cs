using System.ComponentModel.DataAnnotations;

namespace TelegramBotAPI.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        //public bool IsCityCenter { get; set; }
    }
}
