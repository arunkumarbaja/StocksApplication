using StocksApp.Entites;
using System.ComponentModel.DataAnnotations;

namespace StocksApp.ServiceContracts.DTO
{
    public class SellOrderRequest
    {
        [Required(ErrorMessage = "StockSymbolRequired")]
        public string? StockOrderName { get; set; }
        [Required(ErrorMessage = "StockNameRequired")]
        public string? StockOrderSymbol { get; set; }
        public DateTime DateAndTimeofBuyOrder { get; set; }
        [Range(1, 100000)]
        public uint Quantity { get; set; }
        [Range(1, 10000)]
        public double Price { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null)
                return false;
            if(obj is not SellOrderResponse)
                return false;
            
            BuyOrderResponse? response = obj as BuyOrderResponse;
            return StockOrderName==response.StockOrderName && StockOrderSymbol == response.StockOrderSymbol && Price == response.Price;

        }
        public SellOrder ToSellOrder()
        {
            SellOrder sellOrderObj = new SellOrder()
            {
                StockOrderName = StockOrderName,
                StockOrderSymbol = StockOrderSymbol,
                DateAndTimeofBuyOrder = DateAndTimeofBuyOrder,
                Quantity = Quantity,
                Price = Price,
            };   
            return sellOrderObj;
        }
    }
}
