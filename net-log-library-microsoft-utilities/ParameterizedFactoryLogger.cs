using Microsoft.Extensions.Logging;

namespace net_log_library_microsoft_utilities
{
    public sealed class ParameterizedFactoryLogger
    {
        static ParameterizedFactoryLogger()
        {
        }
        
        private static readonly ParameterizedFactoryLogger instance = new ParameterizedFactoryLogger();

        public static ParameterizedFactoryLogger Instance
        {
            get
            {
                return instance;
            }
        }

        private ILoggerFactory loggerFactory;

        private ParameterizedFactoryLogger()
        {
            loggerFactory = null!;
        }

        public void Configure(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        public ILogger<T> CreateLogger<T>()
        {
            if (loggerFactory == null)
                throw new ArgumentNullException("The Configure method must be called in the application configuration.");

            return loggerFactory.CreateLogger<T>();
        }
    }
}
