using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WowParser.Main.JsonService.Parsers;

namespace WowParser.Main.ConsoleCommands
{
    public class ConsimpleExecute
    {
        private const string CommandName = "ConsimpleParse";

        private readonly IWebHost _host;

        private readonly HttpClient _client;


        public ConsimpleExecute(IWebHost host)
        {
            _host = host;
            _client = new HttpClient();
        }


        private int Execute()
        {
            var serviceScopeFactory = (IServiceScopeFactory)_host.Services.GetService(typeof(IServiceScopeFactory));

            using var scope = serviceScopeFactory.CreateScope();

            //TODO: comments.
            // Here can be added scope.ServiceProvider in case the parsing data is need to download/save into database.
            // Use this scope to get a require service which uses PostgreSQL service and
            // pass it to the class which works with parsing

            var parser = Factory.PoweredParser
            (
                _client,
                scope.ServiceProvider.GetRequiredService<ILogger<ConsimpleParser>>()
            );

            parser.TestData().Wait();

            return 0;
        }


        public static void Registry(
            CommandLineApplication app,
            IWebHost host
        )
        {
            app.Command(CommandName, config =>
            {
                config.Description = "Processing json data by url";
                config.HelpOption("-h| --help | -?");

                var commandArgument = config.Argument("url", "");

                config.OnExecute(() =>
                {
                    if (commandArgument.Value != null)
                    {
                        var command = new ConsimpleExecute(host);

                        return command.Execute();
                    }

                    config.ShowHelp();

                    return 1;
                });
            });
        }
    }
}