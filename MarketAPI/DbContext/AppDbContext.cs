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
                new Product { Barcode = "8690526011073", Name = "Eti Tutku", PhotoUrl = "https://images.migrosone.com/sanalmarket/product/7010979/7010979-37b062-1650x1650.jpg", CategoryName = "Snacks" },
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
                new MarketProduct { ProductId = 1, MarketId = 1, Price = 25.50m, DiscountPrice = 24.00m },
                new MarketProduct { ProductId = 1, MarketId = 2, Price = 26.00m },
                new MarketProduct { ProductId = 1, MarketId = 3, Price = 24.50m },
                new MarketProduct { ProductId = 1, MarketId = 4, Price = 25.00m, DiscountPrice = 23.50m },
                new MarketProduct { ProductId = 1, MarketId = 5, Price = 26.50m },
                new MarketProduct { ProductId = 1, MarketId = 6, Price = 25.50m },
                new MarketProduct { ProductId = 2, MarketId = 1, Price = 12.50m, DiscountPrice = 11.00m },
                new MarketProduct { ProductId = 2, MarketId = 2, Price = 13.00m },
                new MarketProduct { ProductId = 2, MarketId = 3, Price = 12.00m, DiscountPrice = 10.50m },
                new MarketProduct { ProductId = 2, MarketId = 4, Price = 12.75m },
                new MarketProduct { ProductId = 2, MarketId = 5, Price = 13.50m, DiscountPrice = 12.00m },
                new MarketProduct { ProductId = 2, MarketId = 6, Price = 12.50m },
                new MarketProduct { ProductId = 3, MarketId = 1, Price = 12.50m },
                new MarketProduct { ProductId = 3, MarketId = 2, Price = 13.00m, DiscountPrice = 11.50m },
                new MarketProduct { ProductId = 3, MarketId = 3, Price = 12.00m },
                new MarketProduct { ProductId = 3, MarketId = 4, Price = 12.75m, DiscountPrice = 11.00m },
                new MarketProduct { ProductId = 3, MarketId = 5, Price = 13.50m },
                new MarketProduct { ProductId = 3, MarketId = 6, Price = 12.50m, DiscountPrice = 10.99m },
                new MarketProduct { ProductId = 4, MarketId = 1, Price = 18.00m, DiscountPrice = 16.50m },
                new MarketProduct { ProductId = 4, MarketId = 2, Price = 18.50m },
                new MarketProduct { ProductId = 4, MarketId = 3, Price = 17.50m },
                new MarketProduct { ProductId = 4, MarketId = 4, Price = 18.00m, DiscountPrice = 17.00m },
                new MarketProduct { ProductId = 4, MarketId = 5, Price = 19.00m },
                new MarketProduct { ProductId = 4, MarketId = 6, Price = 18.00m },
                new MarketProduct { ProductId = 5, MarketId = 1, Price = 15.00m },
                new MarketProduct { ProductId = 5, MarketId = 2, Price = 15.50m, DiscountPrice = 14.00m },
                new MarketProduct { ProductId = 5, MarketId = 3, Price = 14.50m },
                new MarketProduct { ProductId = 5, MarketId = 4, Price = 15.00m },
                new MarketProduct { ProductId = 5, MarketId = 5, Price = 16.00m, DiscountPrice = 15.00m },
                new MarketProduct { ProductId = 5, MarketId = 6, Price = 15.00m },
                new MarketProduct { ProductId = 6, MarketId = 1, Price = 14.50m, DiscountPrice = 13.50m },
                new MarketProduct { ProductId = 6, MarketId = 2, Price = 15.00m },
                new MarketProduct { ProductId = 6, MarketId = 3, Price = 14.00m },
                new MarketProduct { ProductId = 6, MarketId = 4, Price = 14.50m, DiscountPrice = 13.75m },
                new MarketProduct { ProductId = 6, MarketId = 5, Price = 15.50m },
                new MarketProduct { ProductId = 6, MarketId = 6, Price = 14.50m },
                new MarketProduct { ProductId = 7, MarketId = 1, Price = 22.00m },
                new MarketProduct { ProductId = 7, MarketId = 2, Price = 22.50m, DiscountPrice = 20.50m },
                new MarketProduct { ProductId = 7, MarketId = 3, Price = 21.50m },
                new MarketProduct { ProductId = 7, MarketId = 4, Price = 22.00m },
                new MarketProduct { ProductId = 7, MarketId = 5, Price = 23.00m, DiscountPrice = 21.00m },
                new MarketProduct { ProductId = 7, MarketId = 6, Price = 22.00m },
                new MarketProduct { ProductId = 8, MarketId = 1, Price = 45.00m, DiscountPrice = 40.00m },
                new MarketProduct { ProductId = 8, MarketId = 2, Price = 46.00m },
                new MarketProduct { ProductId = 8, MarketId = 3, Price = 44.00m },
                new MarketProduct { ProductId = 8, MarketId = 4, Price = 45.50m, DiscountPrice = 42.00m },
                new MarketProduct { ProductId = 8, MarketId = 5, Price = 47.00m },
                new MarketProduct { ProductId = 8, MarketId = 6, Price = 45.00m },
                new MarketProduct { ProductId = 9, MarketId = 1, Price = 35.00m },
                new MarketProduct { ProductId = 9, MarketId = 2, Price = 35.50m, DiscountPrice = 33.00m },
                new MarketProduct { ProductId = 9, MarketId = 3, Price = 34.50m },
                new MarketProduct { ProductId = 9, MarketId = 4, Price = 35.00m },
                new MarketProduct { ProductId = 9, MarketId = 5, Price = 36.00m, DiscountPrice = 34.00m },
                new MarketProduct { ProductId = 9, MarketId = 6, Price = 35.00m },
                new MarketProduct { ProductId = 10, MarketId = 1, Price = 8.50m, DiscountPrice = 7.50m },
                new MarketProduct { ProductId = 10, MarketId = 2, Price = 9.00m },
                new MarketProduct { ProductId = 10, MarketId = 3, Price = 8.25m },
                new MarketProduct { ProductId = 10, MarketId = 4, Price = 8.75m, DiscountPrice = 8.00m },
                new MarketProduct { ProductId = 10, MarketId = 5, Price = 9.50m },
                new MarketProduct { ProductId = 10, MarketId = 6, Price = 8.50m },
                new MarketProduct { ProductId = 11, MarketId = 1, Price = 28.00m },
                new MarketProduct { ProductId = 11, MarketId = 2, Price = 28.50m, DiscountPrice = 26.00m },
                new MarketProduct { ProductId = 11, MarketId = 3, Price = 27.50m },
                new MarketProduct { ProductId = 11, MarketId = 4, Price = 28.00m, DiscountPrice = 25.50m },
                new MarketProduct { ProductId = 11, MarketId = 5, Price = 29.00m },
                new MarketProduct { ProductId = 11, MarketId = 6, Price = 28.00m }
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