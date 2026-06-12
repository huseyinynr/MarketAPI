using Microsoft.EntityFrameworkCore;
using MarketAPI.Models;

namespace MarketAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Market> Markets => Set<Market>();
    public DbSet<MarketProduct> MarketProducts => Set<MarketProduct>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<MarketProduct>()
            .HasKey(mp => new { mp.ProductId, mp.MarketId });

        var markets = new[]
        {
            new Market { Id = 1, Name = "Lemar", City = "Nicosia" },
            new Market { Id = 2, Name = "Macro", City = "Nicosia" },
            new Market { Id = 3, Name = "Kar", City = "Kyrenia" },
            new Market { Id = 4, Name = "Molto", City = "Kyrenia" },
            new Market { Id = 5, Name = "Belça", City = "Famagusta" },
            new Market { Id = 6, Name = "Kiler", City = "Famagusta" }
        };

        var products = new[]
        {
            new Product { Id = 1, Barcode = "8692005190019", Name = "KOOP Süt 1L Tam Yağlı", PhotoUrl = "https://via.placeholder.com/200?text=KOOP" },
            new Product { Id = 2, Barcode = "5449000000996", Name = "Coca-Cola 330ML", PhotoUrl = "https://via.placeholder.com/200?text=CocaCola" },
            new Product { Id = 3, Barcode = "5449000003102", Name = "Fanta 330ml", PhotoUrl = "https://via.placeholder.com/200?text=Fanta" },
            new Product { Id = 4, Barcode = "8690504020509", Name = "Ülker Çikolatalı Gofret 36GR", PhotoUrl = "https://via.placeholder.com/200?text=Ulker" },
            new Product { Id = 5, Barcode = "8690526011073", Name = "Eti Tutku", PhotoUrl = "https://via.placeholder.com/200?text=EtiTutku" },
            new Product { Id = 6, Barcode = "8690526095417", Name = "Eti Karam Gurme 50GR", PhotoUrl = "https://via.placeholder.com/200?text=EtiKaram" },
            new Product { Id = 7, Barcode = "8690624105650", Name = "Filiz Spagetti Makarna 500G", PhotoUrl = "https://via.placeholder.com/200?text=Filiz" },
            new Product { Id = 8, Barcode = "8690632031231", Name = "Nescafe Gold 100GR", PhotoUrl = "https://via.placeholder.com/200?text=Nescafe" },
            new Product { Id = 9, Barcode = "8711000050127", Name = "Redbull 250ML", PhotoUrl = "https://via.placeholder.com/200?text=Redbull" },
            new Product { Id = 10, Barcode = "8694997019118", Name = "Icy 0.5L Su", PhotoUrl = "https://via.placeholder.com/200?text=Icy" },
            new Product { Id = 11, Barcode = "5053990127740", Name = "Pringles Sour Cream & Onion 165GR", PhotoUrl = "https://via.placeholder.com/200?text=Pringles" }
        };

        var marketProducts = new[]
        {
            new MarketProduct { ProductId = 1, MarketId = 1, Price = 25.50m, DiscountPrice = 24.00m },
            new MarketProduct { ProductId = 1, MarketId = 2, Price = 26.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 1, MarketId = 3, Price = 24.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 1, MarketId = 4, Price = 25.00m, DiscountPrice = 23.50m },
            new MarketProduct { ProductId = 1, MarketId = 5, Price = 26.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 1, MarketId = 6, Price = 25.50m, DiscountPrice = null },

            new MarketProduct { ProductId = 2, MarketId = 1, Price = 12.50m, DiscountPrice = 11.00m },
            new MarketProduct { ProductId = 2, MarketId = 2, Price = 13.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 2, MarketId = 3, Price = 12.00m, DiscountPrice = 10.50m },
            new MarketProduct { ProductId = 2, MarketId = 4, Price = 12.75m, DiscountPrice = null },
            new MarketProduct { ProductId = 2, MarketId = 5, Price = 13.50m, DiscountPrice = 12.00m },
            new MarketProduct { ProductId = 2, MarketId = 6, Price = 12.50m, DiscountPrice = null },

            new MarketProduct { ProductId = 3, MarketId = 1, Price = 12.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 3, MarketId = 2, Price = 13.00m, DiscountPrice = 11.50m },
            new MarketProduct { ProductId = 3, MarketId = 3, Price = 12.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 3, MarketId = 4, Price = 12.75m, DiscountPrice = 11.00m },
            new MarketProduct { ProductId = 3, MarketId = 5, Price = 13.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 3, MarketId = 6, Price = 12.50m, DiscountPrice = 10.99m },

            new MarketProduct { ProductId = 4, MarketId = 1, Price = 18.00m, DiscountPrice = 16.50m },
            new MarketProduct { ProductId = 4, MarketId = 2, Price = 18.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 4, MarketId = 3, Price = 17.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 4, MarketId = 4, Price = 18.00m, DiscountPrice = 17.00m },
            new MarketProduct { ProductId = 4, MarketId = 5, Price = 19.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 4, MarketId = 6, Price = 18.00m, DiscountPrice = null },

            new MarketProduct { ProductId = 5, MarketId = 1, Price = 15.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 5, MarketId = 2, Price = 15.50m, DiscountPrice = 14.00m },
            new MarketProduct { ProductId = 5, MarketId = 3, Price = 14.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 5, MarketId = 4, Price = 15.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 5, MarketId = 5, Price = 16.00m, DiscountPrice = 15.00m },
            new MarketProduct { ProductId = 5, MarketId = 6, Price = 15.00m, DiscountPrice = null },

            new MarketProduct { ProductId = 6, MarketId = 1, Price = 14.50m, DiscountPrice = 13.50m },
            new MarketProduct { ProductId = 6, MarketId = 2, Price = 15.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 6, MarketId = 3, Price = 14.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 6, MarketId = 4, Price = 14.50m, DiscountPrice = 13.75m },
            new MarketProduct { ProductId = 6, MarketId = 5, Price = 15.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 6, MarketId = 6, Price = 14.50m, DiscountPrice = null },

            new MarketProduct { ProductId = 7, MarketId = 1, Price = 22.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 7, MarketId = 2, Price = 22.50m, DiscountPrice = 20.50m },
            new MarketProduct { ProductId = 7, MarketId = 3, Price = 21.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 7, MarketId = 4, Price = 22.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 7, MarketId = 5, Price = 23.00m, DiscountPrice = 21.00m },
            new MarketProduct { ProductId = 7, MarketId = 6, Price = 22.00m, DiscountPrice = null },

            new MarketProduct { ProductId = 8, MarketId = 1, Price = 45.00m, DiscountPrice = 40.00m },
            new MarketProduct { ProductId = 8, MarketId = 2, Price = 46.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 8, MarketId = 3, Price = 44.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 8, MarketId = 4, Price = 45.50m, DiscountPrice = 42.00m },
            new MarketProduct { ProductId = 8, MarketId = 5, Price = 47.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 8, MarketId = 6, Price = 45.00m, DiscountPrice = null },

            new MarketProduct { ProductId = 9, MarketId = 1, Price = 35.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 9, MarketId = 2, Price = 35.50m, DiscountPrice = 33.00m },
            new MarketProduct { ProductId = 9, MarketId = 3, Price = 34.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 9, MarketId = 4, Price = 35.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 9, MarketId = 5, Price = 36.00m, DiscountPrice = 34.00m },
            new MarketProduct { ProductId = 9, MarketId = 6, Price = 35.00m, DiscountPrice = null },

            new MarketProduct { ProductId = 10, MarketId = 1, Price = 8.50m, DiscountPrice = 7.50m },
            new MarketProduct { ProductId = 10, MarketId = 2, Price = 9.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 10, MarketId = 3, Price = 8.25m, DiscountPrice = null },
            new MarketProduct { ProductId = 10, MarketId = 4, Price = 8.75m, DiscountPrice = 8.00m },
            new MarketProduct { ProductId = 10, MarketId = 5, Price = 9.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 10, MarketId = 6, Price = 8.50m, DiscountPrice = null },

            new MarketProduct { ProductId = 11, MarketId = 1, Price = 28.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 11, MarketId = 2, Price = 28.50m, DiscountPrice = 26.00m },
            new MarketProduct { ProductId = 11, MarketId = 3, Price = 27.50m, DiscountPrice = null },
            new MarketProduct { ProductId = 11, MarketId = 4, Price = 28.00m, DiscountPrice = 25.50m },
            new MarketProduct { ProductId = 11, MarketId = 5, Price = 29.00m, DiscountPrice = null },
            new MarketProduct { ProductId = 11, MarketId = 6, Price = 28.00m, DiscountPrice = null }
        };

        modelBuilder.Entity<Market>().HasData(markets);
        modelBuilder.Entity<Product>().HasData(products);
        modelBuilder.Entity<MarketProduct>().HasData(marketProducts);

        base.OnModelCreating(modelBuilder);
    }
}