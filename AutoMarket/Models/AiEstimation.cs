using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Models
{
    public class AiEstimation
    {
        public int Id { get; set; }

        [Required]
        public int CarListingId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal EstimatedPrice { get; set; }

        [Range(0, 1)]
        public double ConfidenceLevel { get; set; }

        public int ComparedListingsCount { get; set; }

        public DateTime DateCalculated { get; set; } = DateTime.UtcNow;
    }
}
