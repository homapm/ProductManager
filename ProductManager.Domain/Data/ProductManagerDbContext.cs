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

            builder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(e => e.Category)
                .IsRequired();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Product> Categories { get; set; }
    }
}
