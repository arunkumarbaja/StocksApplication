namespace StocksApp.Entites
{
    public class SellOrder
    {
        public Guid SellOrderID { get; set; }
        public string? StockOrderName { get; set; }
        public string? StockOrderSymbol { get; set; }
        public DateTime DateAndTimeofBuyOrder { get; set; }
        public uint Quantity { get; set; }
        public double Price { get; set; }
    }
}
