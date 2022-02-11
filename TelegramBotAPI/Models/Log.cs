using System.ComponentModel.DataAnnotations;

namespace TelegramBotAPI.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public DateTime LogTime { get; set; }
        public int UserId { get; set; }
        public string EventType { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public string SqlCommand { get; set; }
        public DateTime EventDate { get; set; }
    }
}
