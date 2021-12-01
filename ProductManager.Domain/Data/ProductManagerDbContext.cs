using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Models;

namespace ProductManager.Domain.Data
{
    public class ProductManagerDbContext : DbContext
    {
        public ProductManagerDbContext(DbContextOptions<ProductManagerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Product> Categories { get; set; }
    }
}
