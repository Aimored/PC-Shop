using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcShop.Data;
using PcShop.Models;
using PcShop.Extensions;

namespace PcShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Checkout()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
                return RedirectToAction("Login", "Account");

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Confirm()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();

            if (cart.Count == 0)
            {
                TempData["Error"] = "Корзина пуста!";
                return RedirectToAction("Index", "Catalog");
            }

            var user = await _context.Users.FindAsync(userId.Value);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var order = new Order
            {
                OrderDate = DateTime.Now,
                CustomerName = user.Username,
                CustomerEmail = user.Email,
                UserId = userId.Value
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var item in cart)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null || product.Stock < item.Quantity)
                {
                    TempData["Error"] = $"Недостаточно товара: {item.Name}";
                    return RedirectToAction("Checkout");
                }

                var orderItem = new OrderItem
                {
                    OrderId = order.OrderId,
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    Price = product.Price
                };

                _context.OrderItems.Add(orderItem);

                product.Stock -= item.Quantity;
            }

            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("cart");

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
