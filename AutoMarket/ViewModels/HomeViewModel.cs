using AutoMarket.Models;

namespace AutoMarket.ViewModels
{
    public class HomeViewModel
    {
        public List<CarListing> Featured { get; set; } = new();
        public List<CarListing> Latest { get; set; } = new();
        public Dictionary<int, AiEstimation?> Estimations { get; set; } = new();
    }
}
