using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace net_log_library_microsoft_utilities
{
    public sealed class GenericFactoryLogger
    {
        static GenericFactoryLogger()
        {
        }

        private static readonly GenericFactoryLogger instance = new GenericFactoryLogger();

        public static GenericFactoryLogger Instance
        {
            get
            {
                return instance;
            }
        }

        private readonly ILoggerFactory loggerFactory;

        private GenericFactoryLogger()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configurationRoot = configurationBuilder.Build();

            loggerFactory = LoggerFactory.Create(logging => {
                bool isWindows = OperatingSystem.IsWindows();
                bool isBrowser = OperatingSystem.IsBrowser();

                if (isWindows)
                    logging.AddFilter<EventLogLoggerProvider>(level => level >= LogLevel.Warning);

                logging.AddConfiguration(configurationRoot.GetSection("Logging"));

                if (!isBrowser)
                    logging.AddConsole();

                logging.AddDebug();

                logging.AddEventSourceLogger();

                if (isWindows)
                    logging.AddEventLog();
            });
        }

        public ILogger<T> CreateLogger<T>()
        {
            return loggerFactory.CreateLogger<T>();
        }
    }
}
