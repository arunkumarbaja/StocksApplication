using Microsoft.AspNetCore.Mvc;
using StocksApp.Entites;
using StocksApp.ServiceContracts;
using StocksApp.ServiceContracts.DTO;
using StocksApplication.ValidationHelpers;
using System.IO.Pipes;
using System.Net;
using System.Security.AccessControl;

namespace StocksApp.Services
{
    public class StockService : IStockServices
    {
        private List<BuyOrder>? _buyOrdersList;

        private List<SellOrder>? _sellOrdersList;
        public StockService()
        {
            _buyOrdersList = new List<BuyOrder>();
            _sellOrdersList = new List<SellOrder>();

            _buyOrdersList.Add(new BuyOrder()
            {
                BuyOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA649"),
                StockOrderName = "Apple",
                StockOrderSymbol= "APPL",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 1,   
                Price=23.23
            });
            _buyOrdersList.Add(new BuyOrder()
            {
                BuyOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA641"),
                StockOrderName = "Microsoft",
                StockOrderSymbol = "MSFT",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 1,
                Price = 23.23
            });
            _buyOrdersList.Add(new BuyOrder()
            {
                BuyOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA642"),
                StockOrderName = "Amazon",
                StockOrderSymbol = "AMZN",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 12,
                Price = 122.23
            });
            _buyOrdersList.Add(new BuyOrder()
            { BuyOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA643"),
                StockOrderName = "Flipkart",
                StockOrderSymbol = "FPKT",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 21,
                Price = 34.23
            });
            _buyOrdersList.Add(new BuyOrder()
            {BuyOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA644"),
                StockOrderName = "NVDIA",
                StockOrderSymbol = "NVDA",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 23,
                Price = 65.23
            });
            _buyOrdersList.Add(new BuyOrder()
            {BuyOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA164"),
                StockOrderName = "Tata",
                StockOrderSymbol = "TATA",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 21,
                Price = 43.23
            });

            //Selling Orders
            _sellOrdersList.Add(new SellOrder()
            {
                SellOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA619"),
                StockOrderName = "Apple",
                StockOrderSymbol = "APPL",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 1,
                Price = 23.23
            });
            _sellOrdersList.Add(new SellOrder()
            {
                SellOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA610"),
                StockOrderName = "Microsoft",
                StockOrderSymbol = "MSFT",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 1,
                Price = 23.23
            });
            _sellOrdersList.Add(new SellOrder()
            {
                SellOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA632"),
                StockOrderName = "Amazon",
                StockOrderSymbol = "AMZN",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 12,
                Price = 122.23
            });
            _sellOrdersList.Add(new SellOrder()
            {
                SellOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA643"),
                StockOrderName = "Flipkart",
                StockOrderSymbol = "FPKT",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 21,
                Price = 34.23
            });
            _sellOrdersList.Add(new SellOrder()
            {
                SellOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA614"),
                StockOrderName = "NVDIA",
                StockOrderSymbol = "NVDA",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 23,
                Price = 65.23
            });
            _sellOrdersList.Add(new SellOrder()
            {
                SellOrderID = Guid.Parse("A4F22945-92A9-480C-9C44-9419304CA611"),
                StockOrderName = "Tata",
                StockOrderSymbol = "TATA",
                DateAndTimeofBuyOrder = DateTime.Parse("2020-02-23"),
                Quantity = 21,
                Price = 43.23
            });
        }

        public BuyOrderResponse CreateBuyOrderRequest(BuyOrderRequest? buyOrderRequest)
        {
           if (buyOrderRequest == null)
                throw new ArgumentNullException(nameof(buyOrderRequest));

            //Model validations
            ValidationHelpersClass.ModelValidations(buyOrderRequest);

            BuyOrder buyOrder = buyOrderRequest.ToByOrder();

          buyOrder.BuyOrderID = Guid.NewGuid();
            _buyOrdersList?.Add(buyOrder);

         BuyOrderResponse buyOrderResponse  =   buyOrder.ToBuyOrderResponse();

            return buyOrderResponse;

        }

        public SellOrderResponse CreateSellOrderRequest(SellOrderRequest? sellOrderRequest)
        {
           if(sellOrderRequest == null)
                throw new ArgumentNullException(nameof(sellOrderRequest));
            //Model validations

            ValidationHelpersClass.ModelValidations(sellOrderRequest);

           SellOrder sellOrder = sellOrderRequest.ToSellOrder();

            sellOrder.SellOrderID = Guid.NewGuid();

            _sellOrdersList.Add(sellOrder);

          SellOrderResponse sellOrderResponse=  sellOrder.ToSellOrderResponse();

            return sellOrderResponse;   
        }

        public List<BuyOrderResponse> GetBuyOrders()
        {
         List<BuyOrderResponse> buyOrderRequests=_buyOrdersList.OrderBy(temp=>temp.DateAndTimeofBuyOrder).Select(temp=>temp.ToBuyOrderResponse()).ToList();

            return buyOrderRequests;
        }

        public List<SellOrderResponse> GetSellOrders()
        {
          List<SellOrderResponse> sellOrderResponses= _sellOrdersList.OrderBy(temp=> temp.DateAndTimeofBuyOrder).Select(temp=>temp.ToSellOrderResponse()).ToList();  
            return sellOrderResponses;
        }



    }
}
