using Microsoft.EntityFrameworkCore;
using ProductApiDemo.Models;
using System.Reflection.Metadata;

namespace ProductApiDemo.Data
{
    public class ProductDbContext: DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public ProductDbContext() { }
        public ProductDbContext(DbContextOptions <ProductDbContext> options) :
               base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .HasIndex(b => b.Code)
                        .IsUnique();

            modelBuilder.Entity<Product>().HasData(DemoData.DemoData.GetProductExamples());
            base.OnModelCreating(modelBuilder);
        }
    }
}
