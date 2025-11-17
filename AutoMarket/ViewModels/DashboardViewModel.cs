namespace AutoMarket.ViewModels
{
    public class DashboardViewModel
    {
        public List<(string Brand, decimal AveragePrice)> AveragePricePerBrand { get; set; } = new();
        public List<(string Seller, int Listings)> ActiveSellers { get; set; } = new();
        public List<(int Year, int Count)> ListingsPerYear { get; set; } = new();
        public List<(string Model, decimal RealPrice, decimal EstimatedPrice)> RealVsAi { get; set; } = new();
    }
}
