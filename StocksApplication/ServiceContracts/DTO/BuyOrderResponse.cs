using StocksApp.Entites;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace StocksApp.ServiceContracts.DTO
{
    public class BuyOrderResponse
    {

        public Guid BuyOrderID { get; set; }
        [Required(ErrorMessage = "StockSymbolRequired")]
        public string? StockOrderName { get; set; }
        [Required(ErrorMessage = "StockNameRequired")]
        public string? StockOrderSymbol { get; set; }
        public DateTime DateAndTimeofBuyOrder { get; set; }
        [Range(1, 100000)]
        public uint Quantity { get; set; }
        [Range(1, 10000)]
        public double Price { get; set; }

        private double TradeAmount { get; set; }    
    }

    public static class BuyOrderExtensionMethod
    {
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder b)
        {
            BuyOrderResponse buyOrderResponse = new BuyOrderResponse()
            {
                StockOrderName = b.StockOrderName,
                StockOrderSymbol = b.StockOrderSymbol,
                DateAndTimeofBuyOrder = b.DateAndTimeofBuyOrder,
                Quantity = b.Quantity,
                Price = b.Price,
            }; 

            return buyOrderResponse;    
        }
       
    }
}
