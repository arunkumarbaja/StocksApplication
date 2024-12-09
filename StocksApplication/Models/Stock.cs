using System.ComponentModel;

namespace StocksApp.Models
{
    public class Stock
    {
        public string? StockName { get; set; }  
        public string? stockSymbol { get; set; }
        public double  CurrentPrice { get; set; }
        public double  LowestPrice { get; set; }
        public double  HighestPrice { get; set; }
        public double  OpenPrice { get; set; }
    }
}
