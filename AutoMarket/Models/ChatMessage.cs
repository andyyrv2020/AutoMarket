using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }

        [Required]
        public string SenderId { get; set; } = string.Empty;

        [Required]
        public string ReceiverId { get; set; } = string.Empty;

        [Required, MaxLength(1000)]
        public string Message { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
