using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WowParser.Model.Datahub;

namespace WowParser.Main.JsonService.Parsers
{
    public class ConsimpleParser : BaseParser
    {
        public ConsimpleParser(HttpClient client, ILogger logger) : base(client, logger)
        {
        }


        public async Task TestData()
        {
            //TODO: to do it dynamic or recursively \ universally
            var paramsData = new Dictionary<string, string>();

            var dataJson = await Execute<City[]>("", paramsData);

            // Console.WriteLine(dataJson);

            foreach (var data in dataJson)
            {
                Logger.LogInformation($" City: ( {data.Title} ). \t Country: ( {data.Country} )\t Sub Country: {data.SubCountry} \t Geo id: {data.GeonameId}");
                Task.Delay(1000).Wait();

                Console.WriteLine("\n \n Press any letter here if you want to continue...");
                Console.WriteLine("or write \"Stop\" in the console to exit.");
                var stopByUser = Console.ReadLine()?.ToLower();
                if (stopByUser != null && stopByUser.Contains("stop"))
                {
                    Environment.Exit(1);
                }
            }

        }
    }
}