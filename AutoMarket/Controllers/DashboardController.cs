using AutoMarket.Data;
using AutoMarket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listings = _context.CarListings.AsNoTracking().ToList();
            var estimations = _context.AiEstimations.AsNoTracking().ToList();

            var model = new DashboardViewModel
            {
                AveragePricePerBrand = listings
                    .GroupBy(l => l.Brand)
                    .Select(g => (g.Key, g.Average(l => l.Price)))
                    .OrderByDescending(x => x.Item2)
                    .ToList(),
                ActiveSellers = listings
                    .GroupBy(l => l.UserId)
                    .Select(g => ($"{g.Key}", g.Count()))
                    .OrderByDescending(x => x.Item2)
                    .ToList(),
                ListingsPerYear = listings
                    .GroupBy(l => l.Year)
                    .Select(g => (g.Key, g.Count()))
                    .OrderBy(x => x.Key)
                    .ToList(),
                RealVsAi = listings
                    .Select(l =>
                    {
                        var ai = estimations.FirstOrDefault(e => e.CarListingId == l.Id);
                        return (Model: $"{l.Brand} {l.Model}", RealPrice: l.Price, EstimatedPrice: ai?.EstimatedPrice ?? l.Price);
                    })
                    .ToList()
            };

            return View(model);
        }
    }
}
