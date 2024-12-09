using Microsoft.AspNetCore.Mvc;
using StocksApp.Entites;
using System.ComponentModel.DataAnnotations;

namespace StocksApp.ServiceContracts.DTO
{
    public class BuyOrderRequest
    {
     
        [Required(ErrorMessage ="StockSymbolRequired")]
        public string? StockOrderName { get; set; }
        [Required(ErrorMessage = "StockNameRequired")]
        public string? StockOrderSymbol { get; set; }
        public DateTime DateAndTimeofBuyOrder { get; set; }
        [Range(1,100000)]
        public uint Quantity { get; set; }
        [Range(1,10000)]
        public double Price { get; set; }

        public BuyOrder ToByOrder()
        {
            BuyOrder buyOrderObj = new BuyOrder()
            {
                StockOrderName = StockOrderName,
                StockOrderSymbol = StockOrderSymbol,
                DateAndTimeofBuyOrder = DateAndTimeofBuyOrder,
                Quantity = Quantity,
                Price = Price,
            }; 
            return buyOrderObj;
            
        }
    }
}
