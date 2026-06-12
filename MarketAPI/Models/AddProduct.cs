namespace MarketAPI.Models
{
    public class AddProduct
    {
        public int MarketId { get; set; }
        public string Barcode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public decimal Price { get; set; }
    }
}
