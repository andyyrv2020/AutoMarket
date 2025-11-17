using AutoMarket.Data;
using AutoMarket.Services;
using AutoMarket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.Controllers
{
    public class CarListingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AiEstimationService _aiEstimationService;

        public CarListingController(ApplicationDbContext context, AiEstimationService aiEstimationService)
        {
            _context = context;
            _aiEstimationService = aiEstimationService;
        }

        public IActionResult Index(string? brand, string? city)
        {
            var query = _context.CarListings.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(brand))
            {
                query = query.Where(c => c.Brand.ToLower().Contains(brand.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(c => c.City.ToLower().Contains(city.ToLower()));
            }

            var listings = query.OrderByDescending(c => c.CreatedAt).ToList();
            var estimations = _context.AiEstimations.AsNoTracking().ToList();

            var model = new HomeViewModel
            {
                Featured = listings.Take(3).ToList(),
                Latest = listings,
                Estimations = estimations.ToDictionary(e => e.CarListingId, e => (Models.AiEstimation?)e)
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var listing = _context.CarListings.AsNoTracking().FirstOrDefault(c => c.Id == id);
            if (listing == null)
            {
                return NotFound();
            }

            var estimation = _context.AiEstimations.AsNoTracking().FirstOrDefault(e => e.CarListingId == id);
            if (estimation == null)
            {
                var similar = _context.CarListings.Where(c => c.Brand == listing.Brand && c.Model == listing.Model && c.Year == listing.Year && c.Id != id);
                estimation = _aiEstimationService.CalculateEstimation(listing, similar);
            }

            var messages = _context.ChatMessages.AsNoTracking().OrderByDescending(c => c.Timestamp).Take(4).ToList();
            var dealerLocation = _context.DealerLocations.AsNoTracking().FirstOrDefault(d => d.UserId == listing.UserId);

            var model = new CarListingDetailViewModel
            {
                Listing = listing,
                Estimation = estimation,
                RecentMessages = messages,
                DealerLocation = dealerLocation
            };

            return View(model);
        }
    }
}
