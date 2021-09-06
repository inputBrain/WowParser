using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace WowParser.Main.JsonService
{
    public class BaseParser
    {
        //TODO: find a better way to pass a url
        private const string BaseUrl =
            "https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json";

        protected readonly HttpClient _client;

        protected readonly ILogger Logger;


        public BaseParser(HttpClient client, ILogger logger)
        {
            _client = client;
            Logger = logger;
        }


        public async Task<T> Execute<T>(string action, IDictionary<string, string> paramsData)
        {
            var response = await _client.GetAsync(QueryHelpers.AddQueryString(BaseUrl + action, paramsData));

            var jsonData = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<T>(jsonData, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = false
            });
        }
    }
}