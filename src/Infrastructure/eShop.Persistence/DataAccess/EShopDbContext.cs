using eShop.Persistence.DataAccess.Configurations;
using eShop.Persistence.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence.DataAccess;

public class EShopDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = default!;

    public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.Entity<Product>().HasData(new List<Product>
        {
            new () { Id = 1, Name = "SOLID", ImgUri = "solid.jpg", Price = 11, Description = "SOLID principles book" },
            new () { Id = 2, Name = ".NET", ImgUri = "net.jpg", Price = 12, Description = ".NET Book" },
            new () { Id = 3, Name = "C#", ImgUri = "csharp.jpg", Price = 13, Description = null },
            new () { Id = 4, Name = "CQRS", ImgUri = "cqrs.jpg", Price = 14, Description = null },
            new () { Id = 5, Name = "Clean Architecture", ImgUri = "onion.jpg", Price = 15, Description = null },
            new () { Id = 6, Name = "Tests", ImgUri = "tests.jpg", Price = 16, Description = null },
            new () { Id = 7, Name = "Design Patterns", ImgUri = "designpatterns.jpg", Price = 17, Description = null },
            new () { Id = 8, Name = "Api", ImgUri = "api.jpg", Price = 18, Description = null }
        });
    }
}
