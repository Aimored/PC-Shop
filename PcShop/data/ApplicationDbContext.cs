using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductType> ProductTypes => Set<ProductType>();
        public DbSet<ProductSpecValue> ProductSpecValues => Set<ProductSpecValue>();
        public DbSet<Specification> Specifications => Set<Specification>();
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }  // <- Добавь это
    }
}
