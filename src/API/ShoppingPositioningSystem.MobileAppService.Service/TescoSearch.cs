using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShoppingPositioningSystem.MobileAppService.Service
{
    public class TestSearch
    {
        private readonly IConfiguration _config;
        private HttpClient _client;
        public TestSearch(IConfiguration config)
        {
            _config = config;
            _client = new HttpClient();
        }

        public async Task<string> GetSearch(string searchTerm)
        {
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config["tescoAuthToken"]);
            string uri = string.Format(_config["tescoSearchUrl"], searchTerm);

            var response = await _client.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
