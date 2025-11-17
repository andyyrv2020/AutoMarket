using AutoMarket.Models;

namespace AutoMarket.ViewModels
{
    public class MapViewModel
    {
        public List<CarListing> Listings { get; set; } = new();
        public List<DealerLocation> DealerLocations { get; set; } = new();
    }
}
