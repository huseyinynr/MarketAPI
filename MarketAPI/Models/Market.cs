namespace MarketAPI.Models;

public class Market
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string City { get; set; } = "";


    public List<MarketProduct> MarketProducts { get; set; } = new();
}