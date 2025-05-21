using Microsoft.AspNetCore.Mvc;
using PcShop.Data;

namespace PcShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var popularProducts = _context.Products
                .OrderByDescending(p => p.Id) // Пример — последние товары
                .Take(8)
                .ToList();

            ViewBag.PopularProducts = popularProducts;
            return View();
        }
    }
}
