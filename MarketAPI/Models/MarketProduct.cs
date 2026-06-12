namespace MarketAPI.Models;

public class MarketProduct
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int MarketId { get; set; }
    public Market Market { get; set; } = null!;

    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
}