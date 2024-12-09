using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.ServiceContracts;
using StocksApp.Models;

using StocksApplication.Models;

namespace StocksApplication.Controllers
{
	public class TradeController : Controller
	{
		private readonly IOptions<TradingOptions> _tradingOptions;

		private readonly IFinnhubService _finnhubService;

		private readonly IFinnhubService _finnhubService1;

		public TradeController(IOptions<TradingOptions> tradingOptions, IFinnhubService finnhubService, IFinnhubService finnhubService1)
		{
			_tradingOptions = (IOptions<TradingOptions>)tradingOptions.Value;
			_finnhubService = finnhubService;
			_finnhubService1 = finnhubService1;
		}

		[Route("/Details")]
		public IActionResult Index()
		{
			if ((_tradingOptions.Value.DefaultStockSymbol == null))
				_tradingOptions.Value.DefaultStockSymbol = "AAPL";


			//getting company profile from API Server
			Dictionary<string, object> Companydata = _finnhubService.getCompanyData(_tradingOptions.Value.DefaultStockSymbol);

			//Getting Stock prices of company from API Server
			Dictionary<string, object> Stockdata = _finnhubService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);

			Stock stock = new Stock()
			{
				stockSymbol = _tradingOptions.Value.DefaultStockSymbol,
			};

			if (Companydata != null && Stockdata != null)
			{
				stock = new Stock()
				{
					stockSymbol = Convert.ToString(Companydata["ticker"]),
					StockName = Convert.ToString(Companydata["name"]),
					CurrentPrice = Convert.ToDouble(Stockdata["c"]),
					HighestPrice = Convert.ToDouble(Stockdata["h"]),
					LowestPrice = Convert.ToDouble(Stockdata["l"]),
					OpenPrice = Convert.ToDouble(Stockdata["o"]),

				};
			}
			return View(stock);
		}
	}
}
