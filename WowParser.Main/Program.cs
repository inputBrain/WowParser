using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using WowParser.Main.ConsoleCommands;

namespace WowParser.Main
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var webHost = BuildWebHost(args);
            var commandLineApplication = new CommandLineApplication(false);


            var catapult = commandLineApplication.Command("command", config =>
            {
                config.OnExecute(() =>
                {
                    config.ShowHelp();
                    return 1;
                });
                config.ShowHelp("-h | --help | -?");
            });

            ConsimpleExecute.Registry(catapult, webHost);

            commandLineApplication.Execute(args);

            return 0;

        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: true)
                         .Build();

            return WebHost.CreateDefaultBuilder(args)
                          .UseStartup<Startup>()
                          .Build();
        }
    }
}