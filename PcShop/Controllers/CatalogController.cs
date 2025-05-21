using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcShop.Data;

namespace PcShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ⬇️ ДОБАВЛЕН typeId
        public async Task<IActionResult> Index(int? typeId)
        {
            var productsQuery = _context.Products
                .Include(p => p.Type) // Связь с типом
                .AsQueryable();

            if (typeId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.TypeId == typeId.Value);
            }

            var products = await productsQuery.ToListAsync();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            var products = string.IsNullOrEmpty(query)
                ? await _context.Products.ToListAsync()
                : await _context.Products
                    .Where(p => p.Name.ToLower().Contains(query.ToLower()))
                    .ToListAsync();

            return PartialView("_ProductList", products);
        }
    }
}
