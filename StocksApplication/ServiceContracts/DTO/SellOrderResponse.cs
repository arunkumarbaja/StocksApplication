using StocksApp.Entites;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace StocksApp.ServiceContracts.DTO
{
    public class SellOrderResponse
    {
        public Guid SellOrderID { get; set; }
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

    public static class ToSellOrderResponseClass
    {
        public static SellOrderResponse ToSellOrderResponse(this SellOrder s)
        {
            SellOrderResponse response = new SellOrderResponse()
            {
                StockOrderName = s.StockOrderName,
                StockOrderSymbol = s.StockOrderSymbol,
                Price = s.Price,
                DateAndTimeofBuyOrder = s.DateAndTimeofBuyOrder,
                Quantity = s.Quantity,

            };   

            return response;    

        }
    }
}
