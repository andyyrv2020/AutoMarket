using AutoMarket.Models;

namespace AutoMarket.Services
{
    public class AiEstimationService
    {
        public AiEstimation CalculateEstimation(CarListing car, IEnumerable<CarListing> similarCars)
        {
            var similarList = similarCars.ToList();
            var averagePrice = similarList.Any()
                ? similarList.Average(c => c.Price)
                : car.Price;

            var mileageFactor = 1 - (car.Mileage / 150000.0);
            var hpFactor = 1 + (car.HorsePower / 300.0);
            var fuelAdjustment = car.FuelType.ToLowerInvariant() switch
            {
                "electric" => 1.08,
                "hybrid" => 1.04,
                _ => 1.0
            };

            var estimated = (double)averagePrice * mileageFactor * hpFactor * fuelAdjustment;

            return new AiEstimation
            {
                CarListingId = car.Id,
                EstimatedPrice = (decimal)Math.Round(estimated, 0),
                ConfidenceLevel = Math.Clamp(0.75 + (similarList.Count / 50.0), 0.55, 0.97),
                ComparedListingsCount = similarList.Count,
                DateCalculated = DateTime.UtcNow
            };
        }
    }
}
