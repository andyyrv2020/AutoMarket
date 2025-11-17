using AutoMarket.Data;
using AutoMarket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.Controllers
{
    public class MapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MapController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new MapViewModel
            {
                Listings = _context.CarListings.AsNoTracking().ToList(),
                DealerLocations = _context.DealerLocations.AsNoTracking().ToList()
            };

            return View(model);
        }
    }
}
