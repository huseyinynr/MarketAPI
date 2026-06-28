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

        base.OnModelCreating(modelBuilder);
    }

    public static async Task InitializeAsync(AppDbContext context)
    {
        try
        {
            await context.Database.EnsureCreatedAsync();

            if (context.Markets.Any()) return;

            var markets = new[]
            {
                new Market { Name = "Lemar", City = "Nicosia" },
                new Market { Name = "Macro", City = "Nicosia" },
                new Market { Name = "Kar", City = "Kyrenia" },
                new Market { Name = "Molto", City = "Kyrenia" },
                new Market { Name = "Belça", City = "Famagusta" },
                new Market { Name = "Kiler", City = "Famagusta" }
            };

            var products = new[]
            {
                new Product { Barcode = "8692005190019", Name = "KOOP 1L Tam Yağlı Süt", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8692005190019-1.jpg", CategoryName = "Dairy" },
                new Product { Barcode = "5449000000996", Name = "Coca-Cola 330ML", PhotoUrl = "https://www.torontopizza.com.cy/menu/menu/404-large_default/coca-cola.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "5449000003102", Name = "Fanta 330ml", PhotoUrl = "https://images.migrosone.com/sanalmarket/product/08020000/08020000_1-c20362.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "8690504020509", Name = "Ülker Çikolatalı Gofret 36GR", PhotoUrl = "https://images.migrosone.com/sanalmarket/product/07167716/7167716-c711c5-1650x1650.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8690526083254", Name = "Eti Tutku", PhotoUrl = "https://images.migrosone.com/sanalmarket/product/7010979/7010979-37b062-1650x1650.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8690526095417", Name = "Eti Karam Gurme 50GR", PhotoUrl = "https://images.migrosone.com/macrocenter/product/07160817/7160817-b58034.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8690624105650", Name = "Filiz Spagetti Makarna 500G", PhotoUrl = "https://foodexfoodco.com/storage/uploads/products/5030356-59bd01-1650x1650_500x500.jpg", CategoryName = "Food" },
                new Product { Barcode = "8690632031231", Name = "Nescafe Gold 100GR", PhotoUrl = "https://images.migrosone.com/macrocenter/product/03231301/3231301_1-cbcfab.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "9002490100070", Name = "Redbull Energy Drink 250ML", PhotoUrl = "https://images.migrosone.com/sanalmarket/product/08110030/08110030-a4b666-1650x1650.png", CategoryName = "Beverages" },
                new Product { Barcode = "8694997019118", Name = "Icy 0.5L Su", PhotoUrl = "https://www.icysu.com/uploads/images/0-5-lt-icy-su-8299.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "5053990127740", Name = "Pringles Sour Cream & Onion 165GR", PhotoUrl = "https://images.kglobalservices.com/www.pringles.com_ie/en_ie/product/product_6598150/prod_img-6598524_pringles-sour-cream-amp-onion-200g.png", CategoryName = "Snacks" }
            };

            context.Markets.AddRange(markets);
            context.Products.AddRange(products);
            await context.SaveChangesAsync();

            var marketProducts = new[]
            {
                // KOOP Süt 1L - base 60
                new MarketProduct { ProductId = 1, MarketId = 1, Price = 62.00m, DiscountPrice = 58.00m },
                new MarketProduct { ProductId = 1, MarketId = 2, Price = 60.50m },
                new MarketProduct { ProductId = 1, MarketId = 3, Price = 63.00m },
                new MarketProduct { ProductId = 1, MarketId = 4, Price = 61.00m, DiscountPrice = 59.00m },
                new MarketProduct { ProductId = 1, MarketId = 5, Price = 64.00m },
                new MarketProduct { ProductId = 1, MarketId = 6, Price = 60.00m },
                // Coca-Cola 330ML - base 39.99
                new MarketProduct { ProductId = 2, MarketId = 1, Price = 41.00m, DiscountPrice = 39.00m },
                new MarketProduct { ProductId = 2, MarketId = 2, Price = 39.99m },
                new MarketProduct { ProductId = 2, MarketId = 3, Price = 42.00m },
                new MarketProduct { ProductId = 2, MarketId = 4, Price = 40.50m, DiscountPrice = 38.50m },
                new MarketProduct { ProductId = 2, MarketId = 5, Price = 43.00m },
                new MarketProduct { ProductId = 2, MarketId = 6, Price = 39.99m },
                // Fanta 330ml - base 39.99
                new MarketProduct { ProductId = 3, MarketId = 1, Price = 39.99m },
                new MarketProduct { ProductId = 3, MarketId = 2, Price = 41.00m, DiscountPrice = 39.00m },
                new MarketProduct { ProductId = 3, MarketId = 3, Price = 40.50m },
                new MarketProduct { ProductId = 3, MarketId = 4, Price = 42.00m },
                new MarketProduct { ProductId = 3, MarketId = 5, Price = 39.99m, DiscountPrice = 37.99m },
                new MarketProduct { ProductId = 3, MarketId = 6, Price = 41.00m },
                // Ülker Gofret - base 26.25
                new MarketProduct { ProductId = 4, MarketId = 1, Price = 27.00m, DiscountPrice = 25.00m },
                new MarketProduct { ProductId = 4, MarketId = 2, Price = 26.25m },
                new MarketProduct { ProductId = 4, MarketId = 3, Price = 27.50m },
                new MarketProduct { ProductId = 4, MarketId = 4, Price = 26.50m },
                new MarketProduct { ProductId = 4, MarketId = 5, Price = 26.25m, DiscountPrice = 24.99m },
                new MarketProduct { ProductId = 4, MarketId = 6, Price = 27.00m },
                // Eti Tutku - base 41.99
                new MarketProduct { ProductId = 5, MarketId = 1, Price = 43.00m, DiscountPrice = 41.00m },
                new MarketProduct { ProductId = 5, MarketId = 2, Price = 41.99m },
                new MarketProduct { ProductId = 5, MarketId = 3, Price = 44.00m },
                new MarketProduct { ProductId = 5, MarketId = 4, Price = 42.50m },
                new MarketProduct { ProductId = 5, MarketId = 5, Price = 41.99m, DiscountPrice = 39.99m },
                new MarketProduct { ProductId = 5, MarketId = 6, Price = 43.00m },
                // Eti Karam - base 46.99
                new MarketProduct { ProductId = 6, MarketId = 1, Price = 48.00m },
                new MarketProduct { ProductId = 6, MarketId = 2, Price = 46.99m, DiscountPrice = 44.99m },
                new MarketProduct { ProductId = 6, MarketId = 3, Price = 49.00m },
                new MarketProduct { ProductId = 6, MarketId = 4, Price = 47.50m },
                new MarketProduct { ProductId = 6, MarketId = 5, Price = 48.50m, DiscountPrice = 46.00m },
                new MarketProduct { ProductId = 6, MarketId = 6, Price = 46.99m },
                // Filiz Spagetti - base 62.99
                new MarketProduct { ProductId = 7, MarketId = 1, Price = 64.00m },
                new MarketProduct { ProductId = 7, MarketId = 2, Price = 62.99m, DiscountPrice = 60.00m },
                new MarketProduct { ProductId = 7, MarketId = 3, Price = 65.00m },
                new MarketProduct { ProductId = 7, MarketId = 4, Price = 63.50m, DiscountPrice = 61.00m },
                new MarketProduct { ProductId = 7, MarketId = 5, Price = 64.50m },
                new MarketProduct { ProductId = 7, MarketId = 6, Price = 62.99m },
                // Nescafe Gold - base 493.99
                new MarketProduct { ProductId = 8, MarketId = 1, Price = 499.00m, DiscountPrice = 479.00m },
                new MarketProduct { ProductId = 8, MarketId = 2, Price = 493.99m },
                new MarketProduct { ProductId = 8, MarketId = 3, Price = 505.00m },
                new MarketProduct { ProductId = 8, MarketId = 4, Price = 495.00m, DiscountPrice = 485.00m },
                new MarketProduct { ProductId = 8, MarketId = 5, Price = 510.00m },
                new MarketProduct { ProductId = 8, MarketId = 6, Price = 493.99m },
                // Redbull - base 71.99
                new MarketProduct { ProductId = 9, MarketId = 1, Price = 73.00m },
                new MarketProduct { ProductId = 9, MarketId = 2, Price = 72.00m, DiscountPrice = 69.00m },
                new MarketProduct { ProductId = 9, MarketId = 3, Price = 74.00m },
                new MarketProduct { ProductId = 9, MarketId = 4, Price = 71.99m },
                new MarketProduct { ProductId = 9, MarketId = 5, Price = 75.00m, DiscountPrice = 71.00m },
                new MarketProduct { ProductId = 9, MarketId = 6, Price = 72.50m },
                // Icy Su - base 20
                new MarketProduct { ProductId = 10, MarketId = 1, Price = 20.50m, DiscountPrice = 19.00m },
                new MarketProduct { ProductId = 10, MarketId = 2, Price = 20.00m },
                new MarketProduct { ProductId = 10, MarketId = 3, Price = 21.00m },
                new MarketProduct { ProductId = 10, MarketId = 4, Price = 20.50m },
                new MarketProduct { ProductId = 10, MarketId = 5, Price = 20.00m, DiscountPrice = 18.50m },
                new MarketProduct { ProductId = 10, MarketId = 6, Price = 21.00m },
                // Pringles - base 149.99
                new MarketProduct { ProductId = 11, MarketId = 1, Price = 152.00m },
                new MarketProduct { ProductId = 11, MarketId = 2, Price = 149.99m, DiscountPrice = 144.00m },
                new MarketProduct { ProductId = 11, MarketId = 3, Price = 155.00m },
                new MarketProduct { ProductId = 11, MarketId = 4, Price = 150.00m },
                new MarketProduct { ProductId = 11, MarketId = 5, Price = 149.99m, DiscountPrice = 142.00m },
                new MarketProduct { ProductId = 11, MarketId = 6, Price = 153.00m }
            };

            context.MarketProducts.AddRange(marketProducts);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database initialization error: {ex.Message}");
            throw;
        }
    }
}