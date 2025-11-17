using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMarket.Models
{
    public class CarListing
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;

        [Range(1990, 2030)]
        public int Year { get; set; }

        [MaxLength(50)]
        public string EngineType { get; set; } = string.Empty;

        [MaxLength(30)]
        public string Transmission { get; set; } = string.Empty;

        public int Mileage { get; set; }

        public int HorsePower { get; set; }

        [MaxLength(20)]
        public string FuelType { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [MaxLength(80)]
        public string City { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Url]
        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public AiEstimation? AiEstimation { get; set; }
    }
}
