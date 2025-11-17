using AutoMarket.Models;

namespace AutoMarket.ViewModels
{
    public class CarListingDetailViewModel
    {
        public CarListing Listing { get; set; } = new();
        public AiEstimation? Estimation { get; set; }
        public List<ChatMessage> RecentMessages { get; set; } = new();
        public DealerLocation? DealerLocation { get; set; }
    }
}
