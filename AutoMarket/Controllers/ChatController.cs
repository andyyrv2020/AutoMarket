using AutoMarket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.Controllers
{
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChatController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var messages = _context.ChatMessages.AsNoTracking()
                .OrderByDescending(m => m.Timestamp)
                .Take(10)
                .ToList();
            return View(messages);
        }
    }
}
