namespace MarketAPI.Models
{
    public class MakeDiscount
    {
        public int MarketId { get; set; }
        public int ProductId { get; set; }
        public decimal NewPrice { get; set; }
    }
}
