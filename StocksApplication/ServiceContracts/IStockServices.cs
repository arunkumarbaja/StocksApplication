using StocksApp.ServiceContracts.DTO;

namespace StocksApp.ServiceContracts
{
    public interface IStockServices
    {
        BuyOrderResponse CreateBuyOrderRequest(BuyOrderRequest? buyOrderRequest);

        SellOrderResponse CreateSellOrderRequest(SellOrderRequest? sellOrderRequest);

        List<BuyOrderResponse> GetBuyOrders();

        List<SellOrderResponse> GetSellOrders();


    }
    
}
