using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public int TelegramId { get; set; }  
    }
}
