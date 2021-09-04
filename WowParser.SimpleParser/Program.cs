using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WowParser.SimpleParser
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();


        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }


        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            //TODO: change url according to test task
            var stringTask = client.GetStringAsync("http://api.worldbank.org/v2/country/br?format=json");
            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}