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
                new Product { Barcode = "5053990127740", Name = "Pringles Sour Cream & Onion 165GR", PhotoUrl = "https://images.kglobalservices.com/www.pringles.com_ie/en_ie/product/product_6598150/prod_img-6598524_pringles-sour-cream-amp-onion-200g.png", CategoryName = "Snacks" },
                // --- Beverages ---
                new Product { Barcode = "4060800304360", Name = "7UP Regular 330ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/04/4060800304360-200x200.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "5000382120421", Name = "Barr Cola 330ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2025/05/5000382120421-200x200.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "5060466513563", Name = "Burn Energy Drink 250ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/5060466513563-1-200x200.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "8691381000011", Name = "Beypazarı Maden Suyu 200ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8691381000011-1-200x200.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "8691381000035", Name = "Beypazarı Sade Soda 6'lı", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8691381000035-1-133x200.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "8684483482403", Name = "Bodrum Mandalin Gazozu 250ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2025/05/8684483482403-200x200.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "8690504098256", Name = "Cafe Crown 3'ü1 Arada Normal 13GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/04/8690504098256-200x200.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "8690504096511", Name = "Cafe Crown Caramel Latte 17GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/12/8690504096511-200x200.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "8690504095569", Name = "Cafe Crown Latte Köpüklü 17GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/12/8690504095569-200x200.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "8692034004011", Name = "Bloom Fresh Orange 0.5L", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/BLOOM-PORTT-1-116x200.jpg", CategoryName = "Beverages" },
                new Product { Barcode = "8690504098904", Name = "Cafe Crown 3'ü1 Arada Fındıklı 13GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/06/8690504098904-200x200.jpg", CategoryName = "Beverages" },
                // --- Snacks ---
                new Product { Barcode = "8699141157005", Name = "Biscolata Mood Çikolatalı 40GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8699141157005-1-133x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8699141055189", Name = "Biscolata Starz Bitter 82GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/08/8699141055189-200x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8699141055035", Name = "Biscolata Starz Sütlü 82GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2025/01/8699141055035-200x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8691707140193", Name = "Biscolata Stix Çikolatalı 40GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8691707140193-1-129x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8691707096520", Name = "Biscolata Gofret Veni Çikolata 110GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/09/8691707096520-200x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8699141057039", Name = "Biscolata Mood Night Bitter 125GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8699141057039-1-134x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8699141157531", Name = "Biscolata Pia Çikolatalı 100GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8699141157531-1-133x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8699141058319", Name = "Biscolata Mood Karamel 125GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/04/8699141058319-200x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8690146658313", Name = "Bebeto Jelly Gum Funny Bears 80GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2025/09/8690146658313-200x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8690146122814", Name = "Bebeto Jelly Spaghetti Rainbow 80GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2025/09/8690146122814-200x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8680885254075", Name = "Arı Mini Grissini Sade 30GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8680885254075-1-200x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8691090001033", Name = "Arı Grissini Kepekli 100GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8691090001033-1-156x200.jpg", CategoryName = "Snacks" },
                new Product { Barcode = "8691707140025", Name = "Biscolata Stix Hindistan Cevizli 36GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/08/8691707140025-200x200.jpeg", CategoryName = "Snacks" },
                // --- Dairy ---
                new Product { Barcode = "8690998112353", Name = "Balparmak 90GR Çiçek Balı", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2022/07/8690998112353-200x200.jpg", CategoryName = "Dairy" },
                new Product { Barcode = "8690998112360", Name = "Balparmak 40GR Çiçek Balı", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/05/8690998112360-150x200.jpg", CategoryName = "Dairy" },
                new Product { Barcode = "8694184240073", Name = "Celayır Yağlı Siyah Zeytin 400GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2025/01/8694184240073-188x200.jpg", CategoryName = "Dairy" },
                new Product { Barcode = "8694184241100", Name = "Celayır Kuru Sele Zeytin 400GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2025/01/8694184241100-182x200.jpg", CategoryName = "Dairy" },
                new Product { Barcode = "8694184241124", Name = "Celayır Izgara Yeşil Zeytin 400GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2025/01/8694184241124-200x200.jpg", CategoryName = "Dairy" },
                new Product { Barcode = "8693235554527", Name = "Cheese Partners Gouda 300GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8693235554527-150x200.jpg", CategoryName = "Dairy" },
                new Product { Barcode = "8691316523615", Name = "Eker Kefir Çilekli 1000ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2022/12/8691316523615-1-161x200.jpg", CategoryName = "Dairy" },
                new Product { Barcode = "8691316523622", Name = "Eker Kefir Orman Meyveli 1000ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/03/8691316523622-160x200.jpg", CategoryName = "Dairy" },
                new Product { Barcode = "8691316520546", Name = "Eker Kaymak 200GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/03/8691316520546-200x200.jpg", CategoryName = "Dairy" },
                new Product { Barcode = "8691316523332", Name = "Eker Cecil Peyniri 200GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2022/12/8691316523332-160x200.jpg", CategoryName = "Dairy" },
                // --- Food ---
                new Product { Barcode = "8691573028274", Name = "Burcu Haşlanmış Barbunya 800G", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2025/07/8691573028274-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8691573029271", Name = "Burcu Haşlanmış Fasulye 800G", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/09/8691573029271-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8691573030277", Name = "Burcu Haşlanmış Nohut 800G", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/09/8691573030277-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8691573023194", Name = "Burcu Yaprak Sarma 400GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/12/8691573023194-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8691573024191", Name = "Burcu Lahana Sarması 400GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/02/8691573024191-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8690559020516", Name = "Dardanel Ton Yağda 140GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/02/8690559020516-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8690559021902", Name = "Dardanel Ton Light 140GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/02/8690559021902-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8690559022695", Name = "Dardanel Ton Klasik Poşet 80GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/12/8690559022695-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8005391302162", Name = "Campagna Baked Beans 400GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2022/09/8005391302162-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8690559014584", Name = "Dardanel Sardalya Ekonomik 125GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/01/8690559014584-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8690559015208", Name = "Dardanel Ton 3x80GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8690559015208-133x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8691573092053", Name = "Burcu Meksika Usulü Pilav 250GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2026/04/8691573092053-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8691573092046", Name = "Burcu Nohutlu Pilav 250GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2026/04/8691573092046-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8691573012730", Name = "Burcu Közlenmiş Biber 560GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2026/04/8691573012730-200x200.jpg", CategoryName = "Food" },
                new Product { Barcode = "8691573012570", Name = "Burcu Közlenmiş Patlıcan 540GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2026/04/8691573012570-200x200.jpg", CategoryName = "Food" },
                // --- Cleaning ---
                new Product { Barcode = "8001480023215", Name = "Ace Power Jel Çiçek Kokulu 810GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8001480023215-1-133x200.jpg", CategoryName = "Cleaning" },
                new Product { Barcode = "8001480023208", Name = "Ace Power Jel Ferahlık 810GR", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8001480023208-1-133x200.jpg", CategoryName = "Cleaning" },
                new Product { Barcode = "8700216926515", Name = "Ariel Parlak Renkler 1440ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2026/05/8700216926515-200x200.jpg", CategoryName = "Cleaning" },
                new Product { Barcode = "8682539004104", Name = "Air Wick Elektrikli Ferahlık Kit 19ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/06/8682539004104-200x200.jpg", CategoryName = "Cleaning" },
                // --- Personal Care ---
                new Product { Barcode = "8690637981517", Name = "Axe Deodorant Africa 150ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2022/01/8690637981517-200x200.jpg", CategoryName = "Personal Care" },
                new Product { Barcode = "8690637981494", Name = "Axe Deodorant Dark Temptation 150ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2022/01/8690637981494-200x200.jpeg", CategoryName = "Personal Care" },
                new Product { Barcode = "8690637890567", Name = "Axe Deodorant Ice Chill 150ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2021/08/8690637890567-200x200.jpeg", CategoryName = "Personal Care" },
                new Product { Barcode = "8683130012031", Name = "Axe Deodorant Epic Fresh 150ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/03/8683130012031-146x200.jpg", CategoryName = "Personal Care" },
                new Product { Barcode = "8683130038338", Name = "Axe Deodorant Jungle Fresh 150ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/11/8683130038338-200x200.jpeg", CategoryName = "Personal Care" },
                new Product { Barcode = "8690637981487", Name = "Axe Deodorant Leather & Cookies 150ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2022/09/8690637981487-133x200.jpg", CategoryName = "Personal Care" },
                new Product { Barcode = "8690973030689", Name = "Caldion Deodorant Jeans Men 150ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2025/07/8690973030689-200x200.jpg", CategoryName = "Personal Care" },
                new Product { Barcode = "8690973030412", Name = "Caldion Deodorant Klasik Men 150ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2023/06/8690973030412-201x200.jpg", CategoryName = "Personal Care" },
                new Product { Barcode = "5010724527450", Name = "Batiste Fresh Kuru Şampuan 200ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/10/5010724527450-200x200.jpg", CategoryName = "Personal Care" },
                new Product { Barcode = "5010724527481", Name = "Batiste Original Kuru Şampuan 200ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/10/5010724527481-200x200.jpg", CategoryName = "Personal Care" },
                new Product { Barcode = "5010724527511", Name = "Batiste Tropical Kuru Şampuan 200ML", PhotoUrl = "https://www.kibrissanalmarket.com/wp-content/uploads/2024/10/5010724527511-200x200.jpg", CategoryName = "Personal Care" },
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
                new MarketProduct { ProductId = 11, MarketId = 6, Price = 153.00m },
                // 7UP 330ML - base 48.99
                new MarketProduct { ProductId = 12, MarketId = 1, Price = 50.00m },
                new MarketProduct { ProductId = 12, MarketId = 2, Price = 48.99m, DiscountPrice = 46.00m },
                new MarketProduct { ProductId = 12, MarketId = 3, Price = 51.00m },
                new MarketProduct { ProductId = 12, MarketId = 4, Price = 49.50m },
                new MarketProduct { ProductId = 12, MarketId = 5, Price = 48.99m, DiscountPrice = 45.99m },
                new MarketProduct { ProductId = 12, MarketId = 6, Price = 50.50m },
                // Barr Cola 330ML - base 47.99
                new MarketProduct { ProductId = 13, MarketId = 1, Price = 49.00m },
                new MarketProduct { ProductId = 13, MarketId = 2, Price = 47.99m },
                new MarketProduct { ProductId = 13, MarketId = 3, Price = 50.00m },
                new MarketProduct { ProductId = 13, MarketId = 4, Price = 47.99m, DiscountPrice = 45.00m },
                new MarketProduct { ProductId = 13, MarketId = 5, Price = 49.50m },
                new MarketProduct { ProductId = 13, MarketId = 6, Price = 48.50m },
                // Burn Energy 250ML - base 75.00
                new MarketProduct { ProductId = 14, MarketId = 1, Price = 77.00m },
                new MarketProduct { ProductId = 14, MarketId = 2, Price = 75.00m, DiscountPrice = 71.00m },
                new MarketProduct { ProductId = 14, MarketId = 3, Price = 78.00m },
                new MarketProduct { ProductId = 14, MarketId = 4, Price = 75.00m },
                new MarketProduct { ProductId = 14, MarketId = 5, Price = 79.00m },
                new MarketProduct { ProductId = 14, MarketId = 6, Price = 76.00m },
                // Beypazarı Maden 200ML - base 16.99
                new MarketProduct { ProductId = 15, MarketId = 1, Price = 17.50m },
                new MarketProduct { ProductId = 15, MarketId = 2, Price = 16.99m },
                new MarketProduct { ProductId = 15, MarketId = 3, Price = 17.99m },
                new MarketProduct { ProductId = 15, MarketId = 4, Price = 16.99m, DiscountPrice = 15.99m },
                new MarketProduct { ProductId = 15, MarketId = 5, Price = 18.00m },
                new MarketProduct { ProductId = 15, MarketId = 6, Price = 17.00m },
                // Beypazarı Soda 6'lı - base 89.99
                new MarketProduct { ProductId = 16, MarketId = 1, Price = 92.00m },
                new MarketProduct { ProductId = 16, MarketId = 2, Price = 89.99m, DiscountPrice = 85.00m },
                new MarketProduct { ProductId = 16, MarketId = 3, Price = 93.00m },
                new MarketProduct { ProductId = 16, MarketId = 4, Price = 90.00m },
                new MarketProduct { ProductId = 16, MarketId = 5, Price = 89.99m },
                new MarketProduct { ProductId = 16, MarketId = 6, Price = 91.00m },
                // Bodrum Mandalin 250ML - base 45.53
                new MarketProduct { ProductId = 17, MarketId = 1, Price = 46.99m },
                new MarketProduct { ProductId = 17, MarketId = 2, Price = 45.53m },
                new MarketProduct { ProductId = 17, MarketId = 3, Price = 47.50m },
                new MarketProduct { ProductId = 17, MarketId = 4, Price = 45.53m, DiscountPrice = 43.00m },
                new MarketProduct { ProductId = 17, MarketId = 5, Price = 48.00m },
                new MarketProduct { ProductId = 17, MarketId = 6, Price = 46.00m },
                // Cafe Crown Normal 13GR - base 13.99
                new MarketProduct { ProductId = 18, MarketId = 1, Price = 14.50m },
                new MarketProduct { ProductId = 18, MarketId = 2, Price = 13.99m },
                new MarketProduct { ProductId = 18, MarketId = 3, Price = 14.99m },
                new MarketProduct { ProductId = 18, MarketId = 4, Price = 13.99m, DiscountPrice = 12.99m },
                new MarketProduct { ProductId = 18, MarketId = 5, Price = 14.99m },
                new MarketProduct { ProductId = 18, MarketId = 6, Price = 14.00m },
                // Cafe Crown Caramel Latte 17GR - base 15.99
                new MarketProduct { ProductId = 19, MarketId = 1, Price = 16.50m },
                new MarketProduct { ProductId = 19, MarketId = 2, Price = 15.99m, DiscountPrice = 14.99m },
                new MarketProduct { ProductId = 19, MarketId = 3, Price = 16.99m },
                new MarketProduct { ProductId = 19, MarketId = 4, Price = 15.99m },
                new MarketProduct { ProductId = 19, MarketId = 5, Price = 17.00m },
                new MarketProduct { ProductId = 19, MarketId = 6, Price = 16.00m },
                // Cafe Crown Latte 17GR - base 15.99
                new MarketProduct { ProductId = 20, MarketId = 1, Price = 15.99m },
                new MarketProduct { ProductId = 20, MarketId = 2, Price = 16.50m },
                new MarketProduct { ProductId = 20, MarketId = 3, Price = 15.99m, DiscountPrice = 14.50m },
                new MarketProduct { ProductId = 20, MarketId = 4, Price = 16.99m },
                new MarketProduct { ProductId = 20, MarketId = 5, Price = 15.99m },
                new MarketProduct { ProductId = 20, MarketId = 6, Price = 16.50m },
                // Bloom Fresh Orange 0.5L - base 44.99
                new MarketProduct { ProductId = 21, MarketId = 1, Price = 46.00m },
                new MarketProduct { ProductId = 21, MarketId = 2, Price = 44.99m },
                new MarketProduct { ProductId = 21, MarketId = 3, Price = 47.00m },
                new MarketProduct { ProductId = 21, MarketId = 4, Price = 44.99m, DiscountPrice = 42.99m },
                new MarketProduct { ProductId = 21, MarketId = 5, Price = 46.50m },
                new MarketProduct { ProductId = 21, MarketId = 6, Price = 45.00m },
                // Cafe Crown Fındıklı 13GR - base 13.99
                new MarketProduct { ProductId = 22, MarketId = 1, Price = 13.99m },
                new MarketProduct { ProductId = 22, MarketId = 2, Price = 14.50m },
                new MarketProduct { ProductId = 22, MarketId = 3, Price = 13.99m, DiscountPrice = 12.99m },
                new MarketProduct { ProductId = 22, MarketId = 4, Price = 14.99m },
                new MarketProduct { ProductId = 22, MarketId = 5, Price = 13.99m },
                new MarketProduct { ProductId = 22, MarketId = 6, Price = 14.50m },
                // Biscolata Mood 40GR - base 44.99
                new MarketProduct { ProductId = 23, MarketId = 1, Price = 46.00m },
                new MarketProduct { ProductId = 23, MarketId = 2, Price = 44.99m, DiscountPrice = 42.00m },
                new MarketProduct { ProductId = 23, MarketId = 3, Price = 47.00m },
                new MarketProduct { ProductId = 23, MarketId = 4, Price = 45.00m },
                new MarketProduct { ProductId = 23, MarketId = 5, Price = 44.99m },
                new MarketProduct { ProductId = 23, MarketId = 6, Price = 46.00m },
                // Biscolata Starz Bitter 82GR - base 54.99
                new MarketProduct { ProductId = 24, MarketId = 1, Price = 56.00m },
                new MarketProduct { ProductId = 24, MarketId = 2, Price = 54.99m },
                new MarketProduct { ProductId = 24, MarketId = 3, Price = 57.00m },
                new MarketProduct { ProductId = 24, MarketId = 4, Price = 54.99m, DiscountPrice = 52.00m },
                new MarketProduct { ProductId = 24, MarketId = 5, Price = 56.50m },
                new MarketProduct { ProductId = 24, MarketId = 6, Price = 55.00m },
                // Biscolata Starz Sütlü 82GR - base 54.99
                new MarketProduct { ProductId = 25, MarketId = 1, Price = 54.99m },
                new MarketProduct { ProductId = 25, MarketId = 2, Price = 56.00m, DiscountPrice = 53.00m },
                new MarketProduct { ProductId = 25, MarketId = 3, Price = 54.99m },
                new MarketProduct { ProductId = 25, MarketId = 4, Price = 57.00m },
                new MarketProduct { ProductId = 25, MarketId = 5, Price = 55.50m },
                new MarketProduct { ProductId = 25, MarketId = 6, Price = 54.99m },
                // Biscolata Stix Çikolatalı 40GR - base 54.99
                new MarketProduct { ProductId = 26, MarketId = 1, Price = 56.00m, DiscountPrice = 53.00m },
                new MarketProduct { ProductId = 26, MarketId = 2, Price = 54.99m },
                new MarketProduct { ProductId = 26, MarketId = 3, Price = 57.00m },
                new MarketProduct { ProductId = 26, MarketId = 4, Price = 54.99m },
                new MarketProduct { ProductId = 26, MarketId = 5, Price = 56.00m },
                new MarketProduct { ProductId = 26, MarketId = 6, Price = 55.50m },
                // Biscolata Gofret Veni 110GR - base 69.99
                new MarketProduct { ProductId = 27, MarketId = 1, Price = 71.00m },
                new MarketProduct { ProductId = 27, MarketId = 2, Price = 69.99m, DiscountPrice = 66.00m },
                new MarketProduct { ProductId = 27, MarketId = 3, Price = 72.00m },
                new MarketProduct { ProductId = 27, MarketId = 4, Price = 70.00m },
                new MarketProduct { ProductId = 27, MarketId = 5, Price = 69.99m },
                new MarketProduct { ProductId = 27, MarketId = 6, Price = 71.50m },
                // Biscolata Mood Night Bitter 125GR - base 89.99
                new MarketProduct { ProductId = 28, MarketId = 1, Price = 92.00m },
                new MarketProduct { ProductId = 28, MarketId = 2, Price = 89.99m },
                new MarketProduct { ProductId = 28, MarketId = 3, Price = 93.00m },
                new MarketProduct { ProductId = 28, MarketId = 4, Price = 89.99m, DiscountPrice = 85.00m },
                new MarketProduct { ProductId = 28, MarketId = 5, Price = 91.00m },
                new MarketProduct { ProductId = 28, MarketId = 6, Price = 90.00m },
                // Biscolata Pia Çikolatalı 100GR - base 109.99
                new MarketProduct { ProductId = 29, MarketId = 1, Price = 112.00m, DiscountPrice = 107.00m },
                new MarketProduct { ProductId = 29, MarketId = 2, Price = 109.99m },
                new MarketProduct { ProductId = 29, MarketId = 3, Price = 114.00m },
                new MarketProduct { ProductId = 29, MarketId = 4, Price = 110.00m },
                new MarketProduct { ProductId = 29, MarketId = 5, Price = 109.99m },
                new MarketProduct { ProductId = 29, MarketId = 6, Price = 112.00m },
                // Biscolata Mood Karamel 125GR - base 94.99
                new MarketProduct { ProductId = 30, MarketId = 1, Price = 97.00m },
                new MarketProduct { ProductId = 30, MarketId = 2, Price = 94.99m, DiscountPrice = 90.00m },
                new MarketProduct { ProductId = 30, MarketId = 3, Price = 98.00m },
                new MarketProduct { ProductId = 30, MarketId = 4, Price = 95.00m },
                new MarketProduct { ProductId = 30, MarketId = 5, Price = 94.99m },
                new MarketProduct { ProductId = 30, MarketId = 6, Price = 96.00m },
                // Bebeto Funny Bears 80GR - base 44.99
                new MarketProduct { ProductId = 31, MarketId = 1, Price = 46.00m },
                new MarketProduct { ProductId = 31, MarketId = 2, Price = 44.99m },
                new MarketProduct { ProductId = 31, MarketId = 3, Price = 47.00m },
                new MarketProduct { ProductId = 31, MarketId = 4, Price = 44.99m, DiscountPrice = 42.00m },
                new MarketProduct { ProductId = 31, MarketId = 5, Price = 45.50m },
                new MarketProduct { ProductId = 31, MarketId = 6, Price = 44.99m },
                // Bebeto Spaghetti Rainbow 80GR - base 44.99
                new MarketProduct { ProductId = 32, MarketId = 1, Price = 44.99m },
                new MarketProduct { ProductId = 32, MarketId = 2, Price = 46.00m },
                new MarketProduct { ProductId = 32, MarketId = 3, Price = 44.99m, DiscountPrice = 41.99m },
                new MarketProduct { ProductId = 32, MarketId = 4, Price = 47.00m },
                new MarketProduct { ProductId = 32, MarketId = 5, Price = 45.50m },
                new MarketProduct { ProductId = 32, MarketId = 6, Price = 44.99m },
                // Arı Mini Grissini Sade 30GR - base 31.99
                new MarketProduct { ProductId = 33, MarketId = 1, Price = 33.00m },
                new MarketProduct { ProductId = 33, MarketId = 2, Price = 31.99m },
                new MarketProduct { ProductId = 33, MarketId = 3, Price = 33.50m },
                new MarketProduct { ProductId = 33, MarketId = 4, Price = 31.99m, DiscountPrice = 29.99m },
                new MarketProduct { ProductId = 33, MarketId = 5, Price = 32.50m },
                new MarketProduct { ProductId = 33, MarketId = 6, Price = 31.99m },
                // Arı Grissini Kepekli 100GR - base 79.99
                new MarketProduct { ProductId = 34, MarketId = 1, Price = 82.00m },
                new MarketProduct { ProductId = 34, MarketId = 2, Price = 79.99m, DiscountPrice = 75.00m },
                new MarketProduct { ProductId = 34, MarketId = 3, Price = 83.00m },
                new MarketProduct { ProductId = 34, MarketId = 4, Price = 80.00m },
                new MarketProduct { ProductId = 34, MarketId = 5, Price = 79.99m },
                new MarketProduct { ProductId = 34, MarketId = 6, Price = 81.00m },
                // Biscolata Stix Hindistan 36GR - base 69.99
                new MarketProduct { ProductId = 35, MarketId = 1, Price = 71.00m },
                new MarketProduct { ProductId = 35, MarketId = 2, Price = 69.99m },
                new MarketProduct { ProductId = 35, MarketId = 3, Price = 72.00m },
                new MarketProduct { ProductId = 35, MarketId = 4, Price = 69.99m, DiscountPrice = 66.00m },
                new MarketProduct { ProductId = 35, MarketId = 5, Price = 70.50m },
                new MarketProduct { ProductId = 35, MarketId = 6, Price = 71.00m },
                // Balparmak 90GR Çiçek Balı - base 177.99
                new MarketProduct { ProductId = 36, MarketId = 1, Price = 182.00m },
                new MarketProduct { ProductId = 36, MarketId = 2, Price = 177.99m, DiscountPrice = 169.00m },
                new MarketProduct { ProductId = 36, MarketId = 3, Price = 184.00m },
                new MarketProduct { ProductId = 36, MarketId = 4, Price = 178.00m },
                new MarketProduct { ProductId = 36, MarketId = 5, Price = 177.99m },
                new MarketProduct { ProductId = 36, MarketId = 6, Price = 180.00m },
                // Balparmak 40GR Çiçek Balı - base 135.99
                new MarketProduct { ProductId = 37, MarketId = 1, Price = 139.00m },
                new MarketProduct { ProductId = 37, MarketId = 2, Price = 135.99m },
                new MarketProduct { ProductId = 37, MarketId = 3, Price = 140.00m },
                new MarketProduct { ProductId = 37, MarketId = 4, Price = 135.99m, DiscountPrice = 129.00m },
                new MarketProduct { ProductId = 37, MarketId = 5, Price = 137.00m },
                new MarketProduct { ProductId = 37, MarketId = 6, Price = 136.00m },
                // Celayır Yağlı Siyah Zeytin 400GR - base 149.99
                new MarketProduct { ProductId = 38, MarketId = 1, Price = 154.00m },
                new MarketProduct { ProductId = 38, MarketId = 2, Price = 149.99m, DiscountPrice = 144.00m },
                new MarketProduct { ProductId = 38, MarketId = 3, Price = 155.00m },
                new MarketProduct { ProductId = 38, MarketId = 4, Price = 150.00m },
                new MarketProduct { ProductId = 38, MarketId = 5, Price = 149.99m },
                new MarketProduct { ProductId = 38, MarketId = 6, Price = 152.00m },
                // Celayır Kuru Sele Zeytin 400GR - base 149.99
                new MarketProduct { ProductId = 39, MarketId = 1, Price = 149.99m },
                new MarketProduct { ProductId = 39, MarketId = 2, Price = 153.00m },
                new MarketProduct { ProductId = 39, MarketId = 3, Price = 149.99m, DiscountPrice = 143.00m },
                new MarketProduct { ProductId = 39, MarketId = 4, Price = 155.00m },
                new MarketProduct { ProductId = 39, MarketId = 5, Price = 151.00m },
                new MarketProduct { ProductId = 39, MarketId = 6, Price = 149.99m },
                // Celayır Izgara Yeşil Zeytin 400GR - base 259.99
                new MarketProduct { ProductId = 40, MarketId = 1, Price = 265.00m },
                new MarketProduct { ProductId = 40, MarketId = 2, Price = 259.99m, DiscountPrice = 249.00m },
                new MarketProduct { ProductId = 40, MarketId = 3, Price = 268.00m },
                new MarketProduct { ProductId = 40, MarketId = 4, Price = 260.00m },
                new MarketProduct { ProductId = 40, MarketId = 5, Price = 259.99m },
                new MarketProduct { ProductId = 40, MarketId = 6, Price = 263.00m },
                // Cheese Partners Gouda 300GR - base 216.99
                new MarketProduct { ProductId = 41, MarketId = 1, Price = 221.00m },
                new MarketProduct { ProductId = 41, MarketId = 2, Price = 216.99m },
                new MarketProduct { ProductId = 41, MarketId = 3, Price = 224.00m },
                new MarketProduct { ProductId = 41, MarketId = 4, Price = 216.99m, DiscountPrice = 209.00m },
                new MarketProduct { ProductId = 41, MarketId = 5, Price = 219.00m },
                new MarketProduct { ProductId = 41, MarketId = 6, Price = 217.00m },
                // Eker Kefir Çilekli 1000ML - base 168.99
                new MarketProduct { ProductId = 42, MarketId = 1, Price = 173.00m },
                new MarketProduct { ProductId = 42, MarketId = 2, Price = 168.99m, DiscountPrice = 162.00m },
                new MarketProduct { ProductId = 42, MarketId = 3, Price = 175.00m },
                new MarketProduct { ProductId = 42, MarketId = 4, Price = 169.00m },
                new MarketProduct { ProductId = 42, MarketId = 5, Price = 168.99m },
                new MarketProduct { ProductId = 42, MarketId = 6, Price = 171.00m },
                // Eker Kefir Orman Meyveli 1000ML - base 168.99
                new MarketProduct { ProductId = 43, MarketId = 1, Price = 168.99m },
                new MarketProduct { ProductId = 43, MarketId = 2, Price = 172.00m },
                new MarketProduct { ProductId = 43, MarketId = 3, Price = 168.99m, DiscountPrice = 161.00m },
                new MarketProduct { ProductId = 43, MarketId = 4, Price = 174.00m },
                new MarketProduct { ProductId = 43, MarketId = 5, Price = 170.00m },
                new MarketProduct { ProductId = 43, MarketId = 6, Price = 168.99m },
                // Eker Kaymak 200GR - base 205.99
                new MarketProduct { ProductId = 44, MarketId = 1, Price = 210.00m, DiscountPrice = 200.00m },
                new MarketProduct { ProductId = 44, MarketId = 2, Price = 205.99m },
                new MarketProduct { ProductId = 44, MarketId = 3, Price = 213.00m },
                new MarketProduct { ProductId = 44, MarketId = 4, Price = 206.00m },
                new MarketProduct { ProductId = 44, MarketId = 5, Price = 205.99m },
                new MarketProduct { ProductId = 44, MarketId = 6, Price = 208.00m },
                // Eker Cecil Peyniri 200GR - base 219.99
                new MarketProduct { ProductId = 45, MarketId = 1, Price = 224.00m },
                new MarketProduct { ProductId = 45, MarketId = 2, Price = 219.99m, DiscountPrice = 212.00m },
                new MarketProduct { ProductId = 45, MarketId = 3, Price = 226.00m },
                new MarketProduct { ProductId = 45, MarketId = 4, Price = 220.00m },
                new MarketProduct { ProductId = 45, MarketId = 5, Price = 219.99m },
                new MarketProduct { ProductId = 45, MarketId = 6, Price = 222.00m },
                // Burcu Barbunya 800G - base 109.99
                new MarketProduct { ProductId = 46, MarketId = 1, Price = 112.00m },
                new MarketProduct { ProductId = 46, MarketId = 2, Price = 109.99m, DiscountPrice = 104.00m },
                new MarketProduct { ProductId = 46, MarketId = 3, Price = 113.00m },
                new MarketProduct { ProductId = 46, MarketId = 4, Price = 110.00m },
                new MarketProduct { ProductId = 46, MarketId = 5, Price = 109.99m },
                new MarketProduct { ProductId = 46, MarketId = 6, Price = 111.00m },
                // Burcu Fasulye 800G - base 99.99
                new MarketProduct { ProductId = 47, MarketId = 1, Price = 102.00m },
                new MarketProduct { ProductId = 47, MarketId = 2, Price = 99.99m },
                new MarketProduct { ProductId = 47, MarketId = 3, Price = 103.00m },
                new MarketProduct { ProductId = 47, MarketId = 4, Price = 99.99m, DiscountPrice = 95.00m },
                new MarketProduct { ProductId = 47, MarketId = 5, Price = 101.00m },
                new MarketProduct { ProductId = 47, MarketId = 6, Price = 100.00m },
                // Burcu Nohut 800G - base 99.99
                new MarketProduct { ProductId = 48, MarketId = 1, Price = 99.99m },
                new MarketProduct { ProductId = 48, MarketId = 2, Price = 102.00m },
                new MarketProduct { ProductId = 48, MarketId = 3, Price = 99.99m, DiscountPrice = 94.00m },
                new MarketProduct { ProductId = 48, MarketId = 4, Price = 103.00m },
                new MarketProduct { ProductId = 48, MarketId = 5, Price = 100.00m },
                new MarketProduct { ProductId = 48, MarketId = 6, Price = 99.99m },
                // Burcu Yaprak Sarma 400GR - base 231.99
                new MarketProduct { ProductId = 49, MarketId = 1, Price = 236.00m },
                new MarketProduct { ProductId = 49, MarketId = 2, Price = 231.99m, DiscountPrice = 219.00m },
                new MarketProduct { ProductId = 49, MarketId = 3, Price = 239.00m },
                new MarketProduct { ProductId = 49, MarketId = 4, Price = 232.00m },
                new MarketProduct { ProductId = 49, MarketId = 5, Price = 231.99m },
                new MarketProduct { ProductId = 49, MarketId = 6, Price = 234.00m },
                // Burcu Lahana Sarması 400GR - base 159.99
                new MarketProduct { ProductId = 50, MarketId = 1, Price = 163.00m },
                new MarketProduct { ProductId = 50, MarketId = 2, Price = 159.99m },
                new MarketProduct { ProductId = 50, MarketId = 3, Price = 165.00m },
                new MarketProduct { ProductId = 50, MarketId = 4, Price = 159.99m, DiscountPrice = 152.00m },
                new MarketProduct { ProductId = 50, MarketId = 5, Price = 161.00m },
                new MarketProduct { ProductId = 50, MarketId = 6, Price = 160.00m },
                // Dardanel Ton Yağda 140GR - base 129.99
                new MarketProduct { ProductId = 51, MarketId = 1, Price = 133.00m },
                new MarketProduct { ProductId = 51, MarketId = 2, Price = 129.99m, DiscountPrice = 124.00m },
                new MarketProduct { ProductId = 51, MarketId = 3, Price = 134.00m },
                new MarketProduct { ProductId = 51, MarketId = 4, Price = 130.00m },
                new MarketProduct { ProductId = 51, MarketId = 5, Price = 129.99m },
                new MarketProduct { ProductId = 51, MarketId = 6, Price = 131.00m },
                // Dardanel Ton Light 140GR - base 129.99
                new MarketProduct { ProductId = 52, MarketId = 1, Price = 129.99m },
                new MarketProduct { ProductId = 52, MarketId = 2, Price = 133.00m },
                new MarketProduct { ProductId = 52, MarketId = 3, Price = 129.99m, DiscountPrice = 123.00m },
                new MarketProduct { ProductId = 52, MarketId = 4, Price = 134.00m },
                new MarketProduct { ProductId = 52, MarketId = 5, Price = 131.00m },
                new MarketProduct { ProductId = 52, MarketId = 6, Price = 129.99m },
                // Dardanel Ton Poşet 80GR - base 99.99
                new MarketProduct { ProductId = 53, MarketId = 1, Price = 102.00m, DiscountPrice = 97.00m },
                new MarketProduct { ProductId = 53, MarketId = 2, Price = 99.99m },
                new MarketProduct { ProductId = 53, MarketId = 3, Price = 103.00m },
                new MarketProduct { ProductId = 53, MarketId = 4, Price = 100.00m },
                new MarketProduct { ProductId = 53, MarketId = 5, Price = 99.99m },
                new MarketProduct { ProductId = 53, MarketId = 6, Price = 101.00m },
                // Campagna Baked Beans 400GR - base 78.99
                new MarketProduct { ProductId = 54, MarketId = 1, Price = 81.00m },
                new MarketProduct { ProductId = 54, MarketId = 2, Price = 78.99m },
                new MarketProduct { ProductId = 54, MarketId = 3, Price = 82.00m },
                new MarketProduct { ProductId = 54, MarketId = 4, Price = 78.99m, DiscountPrice = 74.00m },
                new MarketProduct { ProductId = 54, MarketId = 5, Price = 80.00m },
                new MarketProduct { ProductId = 54, MarketId = 6, Price = 79.00m },
                // Dardanel Sardalya 125GR - base 107.99
                new MarketProduct { ProductId = 55, MarketId = 1, Price = 110.00m },
                new MarketProduct { ProductId = 55, MarketId = 2, Price = 107.99m, DiscountPrice = 102.00m },
                new MarketProduct { ProductId = 55, MarketId = 3, Price = 111.00m },
                new MarketProduct { ProductId = 55, MarketId = 4, Price = 108.00m },
                new MarketProduct { ProductId = 55, MarketId = 5, Price = 107.99m },
                new MarketProduct { ProductId = 55, MarketId = 6, Price = 109.00m },
                // Dardanel Ton 3x80GR - base 205.99
                new MarketProduct { ProductId = 56, MarketId = 1, Price = 210.00m },
                new MarketProduct { ProductId = 56, MarketId = 2, Price = 205.99m },
                new MarketProduct { ProductId = 56, MarketId = 3, Price = 212.00m },
                new MarketProduct { ProductId = 56, MarketId = 4, Price = 205.99m, DiscountPrice = 196.00m },
                new MarketProduct { ProductId = 56, MarketId = 5, Price = 208.00m },
                new MarketProduct { ProductId = 56, MarketId = 6, Price = 206.00m },
                // Burcu Meksika Pilav 250GR - base 83.99
                new MarketProduct { ProductId = 57, MarketId = 1, Price = 86.00m },
                new MarketProduct { ProductId = 57, MarketId = 2, Price = 83.99m },
                new MarketProduct { ProductId = 57, MarketId = 3, Price = 87.00m },
                new MarketProduct { ProductId = 57, MarketId = 4, Price = 83.99m, DiscountPrice = 79.00m },
                new MarketProduct { ProductId = 57, MarketId = 5, Price = 85.00m },
                new MarketProduct { ProductId = 57, MarketId = 6, Price = 84.00m },
                // Burcu Nohutlu Pilav 250GR - base 83.99
                new MarketProduct { ProductId = 58, MarketId = 1, Price = 83.99m },
                new MarketProduct { ProductId = 58, MarketId = 2, Price = 86.00m },
                new MarketProduct { ProductId = 58, MarketId = 3, Price = 83.99m, DiscountPrice = 78.00m },
                new MarketProduct { ProductId = 58, MarketId = 4, Price = 87.00m },
                new MarketProduct { ProductId = 58, MarketId = 5, Price = 85.00m },
                new MarketProduct { ProductId = 58, MarketId = 6, Price = 83.99m },
                // Burcu Közlenmiş Biber 560GR - base 184.99
                new MarketProduct { ProductId = 59, MarketId = 1, Price = 189.00m },
                new MarketProduct { ProductId = 59, MarketId = 2, Price = 184.99m, DiscountPrice = 175.00m },
                new MarketProduct { ProductId = 59, MarketId = 3, Price = 191.00m },
                new MarketProduct { ProductId = 59, MarketId = 4, Price = 185.00m },
                new MarketProduct { ProductId = 59, MarketId = 5, Price = 184.99m },
                new MarketProduct { ProductId = 59, MarketId = 6, Price = 187.00m },
                // Burcu Közlenmiş Patlıcan 540GR - base 125.99
                new MarketProduct { ProductId = 60, MarketId = 1, Price = 129.00m },
                new MarketProduct { ProductId = 60, MarketId = 2, Price = 125.99m },
                new MarketProduct { ProductId = 60, MarketId = 3, Price = 130.00m },
                new MarketProduct { ProductId = 60, MarketId = 4, Price = 125.99m, DiscountPrice = 119.00m },
                new MarketProduct { ProductId = 60, MarketId = 5, Price = 127.00m },
                new MarketProduct { ProductId = 60, MarketId = 6, Price = 126.00m },
                // Ace Power Jel Çiçek 810GR - base 89.99
                new MarketProduct { ProductId = 61, MarketId = 1, Price = 92.00m },
                new MarketProduct { ProductId = 61, MarketId = 2, Price = 89.99m, DiscountPrice = 84.00m },
                new MarketProduct { ProductId = 61, MarketId = 3, Price = 93.00m },
                new MarketProduct { ProductId = 61, MarketId = 4, Price = 90.00m },
                new MarketProduct { ProductId = 61, MarketId = 5, Price = 89.99m },
                new MarketProduct { ProductId = 61, MarketId = 6, Price = 91.00m },
                // Ace Power Jel Ferahlık 810GR - base 89.99
                new MarketProduct { ProductId = 62, MarketId = 1, Price = 89.99m },
                new MarketProduct { ProductId = 62, MarketId = 2, Price = 92.00m },
                new MarketProduct { ProductId = 62, MarketId = 3, Price = 89.99m, DiscountPrice = 83.00m },
                new MarketProduct { ProductId = 62, MarketId = 4, Price = 93.00m },
                new MarketProduct { ProductId = 62, MarketId = 5, Price = 91.00m },
                new MarketProduct { ProductId = 62, MarketId = 6, Price = 89.99m },
                // Ariel Parlak Renkler 1440ML - base 374.99
                new MarketProduct { ProductId = 63, MarketId = 1, Price = 384.00m },
                new MarketProduct { ProductId = 63, MarketId = 2, Price = 374.99m, DiscountPrice = 359.00m },
                new MarketProduct { ProductId = 63, MarketId = 3, Price = 386.00m },
                new MarketProduct { ProductId = 63, MarketId = 4, Price = 375.00m },
                new MarketProduct { ProductId = 63, MarketId = 5, Price = 374.99m },
                new MarketProduct { ProductId = 63, MarketId = 6, Price = 380.00m },
                // Air Wick Elektrikli Kit 19ML - base 719.99
                new MarketProduct { ProductId = 64, MarketId = 1, Price = 735.00m },
                new MarketProduct { ProductId = 64, MarketId = 2, Price = 719.99m, DiscountPrice = 689.00m },
                new MarketProduct { ProductId = 64, MarketId = 3, Price = 739.00m },
                new MarketProduct { ProductId = 64, MarketId = 4, Price = 720.00m },
                new MarketProduct { ProductId = 64, MarketId = 5, Price = 719.99m },
                new MarketProduct { ProductId = 64, MarketId = 6, Price = 729.00m },
                // Axe Africa 150ML - base 239.99
                new MarketProduct { ProductId = 65, MarketId = 1, Price = 245.00m },
                new MarketProduct { ProductId = 65, MarketId = 2, Price = 239.99m, DiscountPrice = 229.00m },
                new MarketProduct { ProductId = 65, MarketId = 3, Price = 247.00m },
                new MarketProduct { ProductId = 65, MarketId = 4, Price = 240.00m },
                new MarketProduct { ProductId = 65, MarketId = 5, Price = 239.99m },
                new MarketProduct { ProductId = 65, MarketId = 6, Price = 242.00m },
                // Axe Dark Temptation 150ML - base 239.99
                new MarketProduct { ProductId = 66, MarketId = 1, Price = 239.99m },
                new MarketProduct { ProductId = 66, MarketId = 2, Price = 245.00m },
                new MarketProduct { ProductId = 66, MarketId = 3, Price = 239.99m, DiscountPrice = 228.00m },
                new MarketProduct { ProductId = 66, MarketId = 4, Price = 247.00m },
                new MarketProduct { ProductId = 66, MarketId = 5, Price = 242.00m },
                new MarketProduct { ProductId = 66, MarketId = 6, Price = 239.99m },
                // Axe Ice Chill 150ML - base 239.99
                new MarketProduct { ProductId = 67, MarketId = 1, Price = 245.00m, DiscountPrice = 234.00m },
                new MarketProduct { ProductId = 67, MarketId = 2, Price = 239.99m },
                new MarketProduct { ProductId = 67, MarketId = 3, Price = 247.00m },
                new MarketProduct { ProductId = 67, MarketId = 4, Price = 239.99m },
                new MarketProduct { ProductId = 67, MarketId = 5, Price = 243.00m },
                new MarketProduct { ProductId = 67, MarketId = 6, Price = 240.00m },
                // Axe Epic Fresh 150ML - base 239.99
                new MarketProduct { ProductId = 68, MarketId = 1, Price = 242.00m },
                new MarketProduct { ProductId = 68, MarketId = 2, Price = 239.99m },
                new MarketProduct { ProductId = 68, MarketId = 3, Price = 245.00m },
                new MarketProduct { ProductId = 68, MarketId = 4, Price = 239.99m, DiscountPrice = 229.00m },
                new MarketProduct { ProductId = 68, MarketId = 5, Price = 244.00m },
                new MarketProduct { ProductId = 68, MarketId = 6, Price = 240.00m },
                // Axe Jungle Fresh 150ML - base 239.99
                new MarketProduct { ProductId = 69, MarketId = 1, Price = 239.99m },
                new MarketProduct { ProductId = 69, MarketId = 2, Price = 244.00m },
                new MarketProduct { ProductId = 69, MarketId = 3, Price = 239.99m, DiscountPrice = 227.00m },
                new MarketProduct { ProductId = 69, MarketId = 4, Price = 246.00m },
                new MarketProduct { ProductId = 69, MarketId = 5, Price = 241.00m },
                new MarketProduct { ProductId = 69, MarketId = 6, Price = 239.99m },
                // Axe Leather & Cookies 150ML - base 239.99
                new MarketProduct { ProductId = 70, MarketId = 1, Price = 245.00m },
                new MarketProduct { ProductId = 70, MarketId = 2, Price = 239.99m, DiscountPrice = 228.00m },
                new MarketProduct { ProductId = 70, MarketId = 3, Price = 247.00m },
                new MarketProduct { ProductId = 70, MarketId = 4, Price = 240.00m },
                new MarketProduct { ProductId = 70, MarketId = 5, Price = 239.99m },
                new MarketProduct { ProductId = 70, MarketId = 6, Price = 243.00m },
                // Caldion Jeans Men 150ML - base 154.99
                new MarketProduct { ProductId = 71, MarketId = 1, Price = 158.00m },
                new MarketProduct { ProductId = 71, MarketId = 2, Price = 154.99m },
                new MarketProduct { ProductId = 71, MarketId = 3, Price = 159.00m },
                new MarketProduct { ProductId = 71, MarketId = 4, Price = 154.99m, DiscountPrice = 147.00m },
                new MarketProduct { ProductId = 71, MarketId = 5, Price = 156.00m },
                new MarketProduct { ProductId = 71, MarketId = 6, Price = 155.00m },
                // Caldion Klasik Men 150ML - base 154.99
                new MarketProduct { ProductId = 72, MarketId = 1, Price = 154.99m },
                new MarketProduct { ProductId = 72, MarketId = 2, Price = 158.00m },
                new MarketProduct { ProductId = 72, MarketId = 3, Price = 154.99m, DiscountPrice = 146.00m },
                new MarketProduct { ProductId = 72, MarketId = 4, Price = 159.00m },
                new MarketProduct { ProductId = 72, MarketId = 5, Price = 156.00m },
                new MarketProduct { ProductId = 72, MarketId = 6, Price = 154.99m },
                // Batiste Fresh 200ML - base 227.99
                new MarketProduct { ProductId = 73, MarketId = 1, Price = 233.00m },
                new MarketProduct { ProductId = 73, MarketId = 2, Price = 227.99m, DiscountPrice = 217.00m },
                new MarketProduct { ProductId = 73, MarketId = 3, Price = 235.00m },
                new MarketProduct { ProductId = 73, MarketId = 4, Price = 228.00m },
                new MarketProduct { ProductId = 73, MarketId = 5, Price = 227.99m },
                new MarketProduct { ProductId = 73, MarketId = 6, Price = 230.00m },
                // Batiste Original 200ML - base 227.99
                new MarketProduct { ProductId = 74, MarketId = 1, Price = 227.99m },
                new MarketProduct { ProductId = 74, MarketId = 2, Price = 233.00m },
                new MarketProduct { ProductId = 74, MarketId = 3, Price = 227.99m, DiscountPrice = 216.00m },
                new MarketProduct { ProductId = 74, MarketId = 4, Price = 235.00m },
                new MarketProduct { ProductId = 74, MarketId = 5, Price = 230.00m },
                new MarketProduct { ProductId = 74, MarketId = 6, Price = 227.99m },
                // Batiste Tropical 200ML - base 227.99
                new MarketProduct { ProductId = 75, MarketId = 1, Price = 233.00m, DiscountPrice = 222.00m },
                new MarketProduct { ProductId = 75, MarketId = 2, Price = 227.99m },
                new MarketProduct { ProductId = 75, MarketId = 3, Price = 235.00m },
                new MarketProduct { ProductId = 75, MarketId = 4, Price = 228.00m },
                new MarketProduct { ProductId = 75, MarketId = 5, Price = 227.99m },
                new MarketProduct { ProductId = 75, MarketId = 6, Price = 231.00m }
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