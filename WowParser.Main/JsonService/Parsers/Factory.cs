using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace WowParser.Main.JsonService.Parsers
{
    public static class Factory
    {
        public static ConsimpleParser PoweredParser(
            HttpClient client,
            ILogger<ConsimpleParser> logger
        )
        {
            return new ConsimpleParser(client, logger);
        }
    }
}