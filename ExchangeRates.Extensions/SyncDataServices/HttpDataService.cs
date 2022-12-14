using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ExchangeRates.Extensions.SyncDataServices
{
    public class HttpDataService : IHttpDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpDataService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        
        public async Task<HttpResponseMessage> SendGetRequest(string request)
        {
            return await _httpClient.GetAsync(request);
        }

        public async Task SendPostRequest(object message, string destination)
        {
            var httpContent = new StringContent
            (
                JsonConvert.SerializeObject(message),
                Encoding.UTF8,
                "application/json"
            );
            await _httpClient.PostAsync($"{destination}", httpContent);
        }
    }
}