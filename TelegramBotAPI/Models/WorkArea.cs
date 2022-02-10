namespace TelegramBotAPI.Models
{
    public class WorkArea
    {
        public int? WorkingAreaId { get; set; }
        public string? WorkingAreaType { get; set; }
        public int? Number { get; set; }
        public int? MapId { get; set; }
        public bool HasPc { get; set; }
        public bool HasMonitor { get; set; }
        public bool IsBig { get; set; }
        public bool IsSmall { get; set; }
        public bool IsClosed { get; set; }
        public bool IsNearWindow { get; set; }
    }
}
