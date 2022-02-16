using System.ComponentModel.DataAnnotations;

namespace TelegramBotAPI.Models
{
    public class BookType
    {
        [Key]
        public int BookTypeId { get; set; }
        public string Type { get; set; }
    }
}
