using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Models
{
    public class DealerLocation
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        public double Longitude { get; set; }

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}
