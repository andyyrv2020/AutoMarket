using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public int CarListingId { get; set; }

        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
    }
}
