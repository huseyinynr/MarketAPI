namespace MarketAPI.Models;

public class Product
{
    public int Id { get; set; }
    public string Barcode { get; set; } = "";
    public string Name { get; set; } = "";
    public string PhotoUrl { get; set; } = "";
    public string CategoryName { get; set; } = "";

    public List<MarketProduct> MarketProducts { get; set; } = new();
}