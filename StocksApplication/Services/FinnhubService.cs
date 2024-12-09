using Microsoft.VisualBasic;
using StocksApp.ServiceContracts;
using System.Net.Http.Headers;
using System.Text.Json;


namespace StocksApp.Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpClientFactory _httpClientFactory1;
        private readonly IConfiguration _configuration;

        public FinnhubService(IHttpClientFactory httpClientFactory, IHttpClientFactory httpClientFactory1, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _httpClientFactory1 = httpClientFactory1;
            _configuration = configuration;
        }

        public Dictionary<string, object> GetStockPriceQuote(string stockSymbol)
        {
            // IhttpClinetFactory is used for creating a instance for httpclient class 
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                //used for creating new request to any particular url
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinnhunToken"]}"),
                    Method = HttpMethod.Get,
                };

                HttpResponseMessage httpResponseMessage = httpClient.Send(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();

                StreamReader streamReader = new StreamReader(stream);

                string response = streamReader.ReadToEnd();

                Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (responseDictionary == null)
                {
                    throw new InvalidOperationException("No response from Server");
                }
                if (responseDictionary.ContainsKey("error"))
                    throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));

                return responseDictionary;
            }

        }


        public Dictionary<string, object> getCompanyData(string companyname)
        {
            using (HttpClient httpclient = _httpClientFactory1.CreateClient())
            {
                HttpRequestMessage httpRequestMessage1 = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/stock/profile2?symbol={companyname}&token=cs7ujghr01qsceftfuk0cs7ujghr01qsceftfukg"),
                    Method = HttpMethod.Get,
                };
                HttpResponseMessage httpResponseMessage1 = httpclient.Send(httpRequestMessage1);

                Stream stream1 = httpResponseMessage1.Content.ReadAsStream();

                StreamReader streamReader = new StreamReader(stream1);

                string response = streamReader.ReadToEnd();

                Dictionary<string, object>? responseDict = JsonSerializer.Deserialize<Dictionary<string, object>?>(response);

                if (responseDict == null)
                {
                    throw new InvalidOperationException("No response from Server");
                }
                if (responseDict.ContainsKey("error"))
                    throw new InvalidOperationException(Convert.ToString(responseDict["error"]));

                return responseDict;
            }
        }
    }
}

                
               

