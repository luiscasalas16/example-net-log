using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using net_log_library_microsoft_example;
using net_log_library_microsoft_utilities;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace net_log_library_microsoft_console
{
    /*
    https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-7.0
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using IHost host = Host.CreateDefaultBuilder(args)
                    .ConfigureServices((services) =>
                    {
                        services.AddHostedService<Application>();
                    })
                    .Build();

                var loggerFactory = host.Services.GetService<ILoggerFactory>();

                ParameterizedFactoryLogger.Instance.Configure(loggerFactory!);

                host.Run();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());

                Console.WriteLine(ex.ToString());
            }
        }

        public class Application : BackgroundService
        {
            private readonly ILogger<Application> _logger;
            private readonly IConfiguration _configuration;

            public Application(ILogger<Application> logger, IConfiguration configuration)
            {
                _logger = logger;
                _configuration = configuration;
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                _logger.LogCritical("Custom logging critical.");
                _logger.LogError("Custom logging error.");
                _logger.LogWarning("Custom logging warning.");
                _logger.LogInformation("Custom logging information.");
                _logger.LogDebug("Custom logging debug.");
                _logger.LogTrace("Custom logging trace.");

                new GenericComponent().Execute();

                new ParameterizedComponent().Execute();
            }
        }
    }
}