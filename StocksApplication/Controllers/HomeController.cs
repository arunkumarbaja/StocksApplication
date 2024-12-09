using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Options;
using StocksApp;
using StocksApp.Models;
using StocksApp.ServiceContracts;
using StocksApp.ServiceContracts.DTO;
using StocksApp.Services;
using StocksApplication.Models;
using System.Diagnostics.SymbolStore;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace StocksApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinnhubService _finnhubservice;
        private readonly IFinnhubService _finnhubservice1;
        private readonly IStockServices _stockservice;

        private readonly IOptions<TradingOptions> _tradingOptions;
        public HomeController(FinnhubService finnhubservice, FinnhubService finnhubservice1, IOptions<TradingOptions> tradingoptions, StockService stockservice)
        {
            _finnhubservice = finnhubservice;
            _finnhubservice1 = finnhubservice1;

            _tradingOptions = tradingoptions;
            _stockservice = stockservice;   
        }
        [Route("/")]
        [Route("/{Stockname}")]
        public async Task<IActionResult> Index(string Stockname)
        {
            if (_tradingOptions.Value.DefaultStockSymbol == null)
            {
                _tradingOptions.Value.DefaultStockSymbol = "AAPL";
            }


            Dictionary<string, object>? responseDictinory =  _finnhubservice.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol = "AAPL");

            Dictionary<string, object>? reponseDict_ = _finnhubservice1.getCompanyData(_tradingOptions.Value.DefaultStockSymbol = "AAPL");

            Stock stock = new Stock()
            {
                StockName = reponseDict_["name"].ToString(),
                stockSymbol = reponseDict_["ticker"].ToString(),
                CurrentPrice = Convert.ToDouble(responseDictinory["c"].ToString()),
                HighestPrice = Convert.ToDouble(responseDictinory["h"].ToString()),
                LowestPrice = Convert.ToDouble(responseDictinory["l"].ToString()),
                OpenPrice = Convert.ToDouble(responseDictinory["o"].ToString()),
            };

            return View(stock);
        }

        [Route("/Stockname/{CompName}")]
        public async Task<IActionResult> _CompanyName(string CompName)
        {

            Dictionary<string, object>? data =  _finnhubservice1.getCompanyData(CompName);

            CompanyDetails details = new CompanyDetails()
            {
                Name = Convert.ToString(data["name"].ToString()),
                Country = Convert.ToString(data["country"].ToString()),
                Currency = Convert.ToString(data["currency"].ToString()),
                Phone = Convert.ToString(data["phone"].ToString())
            };
            return View(details);
        }


        [Route("/YourOrders")]
        public IActionResult Orders()
        {
            List<BuyOrderResponse> buyorders_list = _stockservice.GetBuyOrders();
            return View(buyorders_list);
        }
        [Route("/YourOrders/SellOrders")]
        public IActionResult SellOrders()
        {
            List<SellOrderResponse> sellorders_list = _stockservice.GetSellOrders();
            return View(sellorders_list);
        }

        [Route("/Home/CreateBuyOrder")]
        public IActionResult CreateBuyOrder()
        {
           
            return View();  
        }
        [HttpPost]
		[Route("/Home/CreateBuyOrder")]
		public IActionResult CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
		{

			BuyOrderResponse buyOrderResponse = _stockservice.CreateBuyOrderRequest(buyOrderRequest);
			return View();
		}
	}



}
