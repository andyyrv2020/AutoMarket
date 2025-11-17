using System.Diagnostics;
using AutoMarket.Data;
using AutoMarket.Models;
using AutoMarket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var listings = _context.CarListings.AsNoTracking().OrderByDescending(c => c.CreatedAt).ToList();
            var estimations = _context.AiEstimations.AsNoTracking().ToDictionary(e => e.CarListingId, e => e as AiEstimation);

            var model = new HomeViewModel
            {
                Featured = listings.Take(3).ToList(),
                Latest = listings,
                Estimations = estimations
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
